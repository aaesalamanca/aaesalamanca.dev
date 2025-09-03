using Aaesalamanca.RazorPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aaesalamanca.RazorPages.Pages;

public class IndexModel(ILogger<IndexModel> logger, PostStore postStore) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly PostStore _postStore = postStore;

    public IReadOnlyList<PostDocument> Posts { get; private set; } = [];

    public void OnGet() => Posts = _postStore.GetAllOrdered();
}
