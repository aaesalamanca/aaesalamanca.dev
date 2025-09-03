using Aaesalamanca.RazorPages.Services;

namespace Aaesalamanca.RazorPages.HostedServices;

public sealed class PostPreloaderHostedService(
    ILogger<PostPreloaderHostedService> logger,
    PostStore postStore
) : IHostedService
{
    private readonly ILogger<PostPreloaderHostedService> _logger = logger;
    private readonly PostStore _postStore = postStore;

    public async Task StartAsync(CancellationToken ct)
    {
        _logger.LogInformation("Preloading posts from GitHub...");

        try
        {
            await _postStore.ReloadAsync(ct);
            _logger.LogInformation("Posts preloaded: {Count}", _postStore.GetAllOrdered().Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error preloading posts at startup.");
            throw;
        }
    }

    public Task StopAsync(CancellationToken ct) => Task.CompletedTask;
}
