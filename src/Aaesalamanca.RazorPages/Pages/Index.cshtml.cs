using Aaesalamanca.RazorPages.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aaesalamanca.RazorPages.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IGitHubPostsClient _gitHubPostsClient;

    public IndexModel(ILogger<IndexModel> logger, IGitHubPostsClient gitHubPostsClient)
    {
        _logger = logger;
        _gitHubPostsClient = gitHubPostsClient;
    }

    public async Task OnGet()
    {
        _ = await _gitHubPostsClient.GetPostFilesAsync();
    }
}
