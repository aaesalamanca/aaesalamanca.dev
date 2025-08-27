namespace Aaesalamanca.RazorPages.Options;

public sealed class GitHubOptions
{
    public string Owner { get; set; } = "aaesalamanca";
    public string Repo { get; set; } = "aaesalamanca.dev";
    public string Branch { get; set; } = "main";
    public string PostsPath { get; set; } = "posts";
    public string Token { get; set; } = string.Empty;
    public string WebhookSecret { get; set; } = string.Empty;
}
