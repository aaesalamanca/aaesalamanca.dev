using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Aaesalamanca.RazorPages.Services;

public sealed class FrontMatterParser
{
    private readonly IDeserializer _yamlDeserializer;

    public FrontMatterParser()
    {
        _yamlDeserializer = new DeserializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();
    }

    public (FrontMatter frontMatter, string markdown, string title) Parse(string input)
    {
        var end = input.IndexOf("\n---", 3, StringComparison.Ordinal);
        var yaml = input[3..end].Trim('\r', '\n', ' ');
        var frontMatter = _yamlDeserializer.Deserialize<FrontMatter>(yaml);
        var markdown = input[(end + 4)..].Trim('\r', '\n');
        var title = ExtractTitle(markdown);

        return (frontMatter, markdown, title);
    }

    private static string ExtractTitle(string markdown)
    {
        using var reader = new StringReader(markdown);

        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            if (line.StartsWith("# "))
            {
                return line[2..].Trim();
            }
        }

        return "There's no title";
    }
}

public sealed class FrontMatter
{
    public required string Description { get; init; }
    public required DateTime PublishedDate { get; init; }
    public DateTime? EditedDate { get; init; }
    public required bool IsDraft { get; init; }
}
