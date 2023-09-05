using Microsoft.CodeAnalysis;


namespace SourceGeneratorWarning;

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public class Generator : IIncrementalGenerator
{
    public static DiagnosticDescriptor WarningWithLink { get; } = new("LIB001",
        "This is the title",
        "This is the message",
        "Build", DiagnosticSeverity.Warning, true,
        "This is the description.",
        helpLinkUri: "https://github.com/dotnet/roslyn");

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterSourceOutput(context.AnalyzerConfigOptionsProvider, (c, t) =>
        {
            // Simulate some issue found while generating source code.
            c.ReportDiagnostic(Diagnostic.Create(WarningWithLink, Location.None));
        });
    }
}