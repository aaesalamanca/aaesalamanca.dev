namespace Aaesalamanca.RazorPages.Clients;

public interface IGitHubPostsClient
{
    Task<IReadOnlyList<GitHubPostFile>> GetPostFilesAsync(CancellationToken ct = default);

    Task<string> DownloadRawPostAsync(string downloadUrl, CancellationToken ct = default);
}

public record GitHubPostFile(string Slug, string DownloadUrl);
