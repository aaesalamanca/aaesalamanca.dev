using Markdig;

namespace Aaesalamanca.RazorPages.Services;

public sealed class MarkdownRenderer
{
    private readonly MarkdownPipeline _pipeline;

    public MarkdownRenderer() =>
        _pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

    public string ToHtml(string markdown) => Markdown.ToHtml(markdown, _pipeline);
}
