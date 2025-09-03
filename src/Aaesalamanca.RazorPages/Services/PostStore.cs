using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Aaesalamanca.RazorPages.Clients;

namespace Aaesalamanca.RazorPages.Services;

public sealed class PostStore(
    IGitHubPostsClient gitHubPostsClient,
    FrontMatterParser frontMatterParser,
    MarkdownRenderer markdownRenderer,
    IWebHostEnvironment webHostEnvironment
)
{
    private readonly IGitHubPostsClient _gitHubPostsClient = gitHubPostsClient;
    private readonly FrontMatterParser _frontMatterParser = frontMatterParser;
    private readonly MarkdownRenderer _markdownRenderer = markdownRenderer;
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
    private ImmutableDictionary<string, PostDocument> _posts = ImmutableDictionary<
        string,
        PostDocument
    >.Empty;

    public async Task ReloadAsync(CancellationToken ct = default)
    {
        var files = await _gitHubPostsClient.GetPostFilesAsync(ct);
        var postsBuilder = ImmutableDictionary.CreateBuilder<string, PostDocument>(
            StringComparer.OrdinalIgnoreCase
        );

        foreach (var file in files)
        {
            var rawFile = await _gitHubPostsClient.DownloadRawPostAsync(file.DownloadUrl, ct);
            var (frontMatter, markdown, title) = _frontMatterParser.Parse(rawFile);

            if (!_webHostEnvironment.IsDevelopment() && frontMatter.IsDraft)
            {
                continue;
            }

            postsBuilder[file.Slug] = new PostDocument(
                file.Slug,
                title,
                _markdownRenderer.ToHtml(markdown),
                frontMatter.PublishedDate,
                frontMatter.EditedDate,
                frontMatter.Description
            );

            var posts = postsBuilder.ToImmutable();
            Interlocked.Exchange(ref _posts, posts);
        }
    }

    public bool TryGetPost(string slug, [NotNullWhen(true)] out PostDocument? post) =>
        _posts.TryGetValue(slug, out post);

    public IReadOnlyList<PostDocument> GetAllOrdered() =>
        _posts.Values.OrderByDescending(p => p.PublishedDate).ToList();
}

public record PostDocument(
    string Slug,
    string Title,
    string Html,
    DateTime PublishedDate,
    DateTime? EditedDate,
    string Description
);
