using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace SolidAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Srp0001MethodShouldNotHaveOut : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "Srp0001";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.Srp0001Title), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.Srp0001MessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.Srp0001Description), Resources.ResourceManager, typeof(Resources));
        private const string Category = "SOLID";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Method);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            // TODO: Replace the following code with your own analysis, generating Diagnostic objects for any issues you find
            var methodSymbol = (IMethodSymbol)context.Symbol;

            foreach (var parameter in methodSymbol.Parameters.Where(parameter => parameter.RefKind == RefKind.Out))
            {
                foreach (var location in parameter.Locations)
                {
                    context.ReportDiagnostic(Diagnostic.Create(Rule,
                                       location,
                                       parameter.Name,
                                       methodSymbol.Name,
                                       nameof(RefKind.Out)
                                       ));
                }
            }
        }

    }
}
