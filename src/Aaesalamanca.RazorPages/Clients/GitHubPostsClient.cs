using System.Text.Json;
using Aaesalamanca.RazorPages.Options;
using Microsoft.Extensions.Options;

namespace Aaesalamanca.RazorPages.Clients;

public class GitHubPostsClient(
    HttpClient httpClient,
    IOptions<GitHubOptions> githubOptions,
    ILogger<GitHubPostsClient> logger
) : IGitHubPostsClient
{
    private readonly HttpClient httpClient = httpClient;
    private readonly ILogger<GitHubPostsClient> _logger = logger;
    private readonly GitHubOptions _gitHubOptions = githubOptions.Value;

    public async Task<string> DownloadRawPostAsync(
        string downloadUrl,
        CancellationToken ct = default
    )
    {
        using var response = await httpClient.GetAsync(downloadUrl, ct);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<IReadOnlyList<GitHubPostFile>> GetPostFilesAsync(
        CancellationToken ct = default
    )
    {
        var url =
            $"/repos/{_gitHubOptions.Owner}/{_gitHubOptions.Repo}/contents/{_gitHubOptions.PostsPath}?href={_gitHubOptions.Branch}";

        using var response = await httpClient.GetAsync(url, ct);
        response.EnsureSuccessStatusCode();

        var bodyStream = await response.Content.ReadAsStreamAsync(ct);
        var bodyJson = await JsonDocument.ParseAsync(bodyStream, cancellationToken: ct);

        var posts = new List<GitHubPostFile>();
        foreach (var item in bodyJson.RootElement.EnumerateArray())
        {
            if (item.GetProperty("type").GetString() != "file")
            {
                continue;
            }

            var name = item.GetProperty("name").GetString() ?? string.Empty;
            if (!name.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var downloadUrl = item.GetProperty("download_url").GetString() ?? string.Empty;
            var slug = Path.GetFileNameWithoutExtension(name);
            posts.Add(new GitHubPostFile(slug, downloadUrl));
        }

        return posts;
    }
}
