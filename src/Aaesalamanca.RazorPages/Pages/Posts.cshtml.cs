using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aaesalamanca.RazorPages.Pages;

public class PostsModel : PageModel
{
    private readonly ILogger<PostsModel> _logger;

    public PostsModel(ILogger<PostsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() { }
}
