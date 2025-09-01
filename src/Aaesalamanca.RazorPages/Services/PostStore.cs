using System.Collections.Immutable;
using Aaesalamanca.RazorPages.Clients;

namespace Aaesalamanca.RazorPages.Services;

public sealed class PostStore
{
    private readonly IGitHubPostsClient _gitHubPostsClient;
    private readonly FrontMatterParser _frontMatterParser;

    public PostStore(IGitHubPostsClient gitHubPostsClient, FrontMatterParser frontMatterParser)
    {
        _gitHubPostsClient = gitHubPostsClient;
        _frontMatterParser = frontMatterParser;
    }

    private readonly ImmutableDictionary<string, PostDocument> _posts = ImmutableDictionary<
        string,
        PostDocument
    >.Empty;
}

public record PostDocument(
    string Slug,
    string Title,
    string Html,
    DateTime PublishedDate,
    DateTime? EditedDate,
    string Description,
    bool IsDraft = true
);
