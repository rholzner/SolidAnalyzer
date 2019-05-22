using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace SolidAnalyzer.DIP
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Dip0001DoNotUseStaticExtension : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "Dip0001";

        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.Dip0001Title), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.Dip0001MessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.Dip0001Description), Resources.ResourceManager, typeof(Resources));
        private const string Category = "SOLID";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Info, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Method);
        }
        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var methodSymbol = (IMethodSymbol)context.Symbol;
            if (methodSymbol.IsStatic && methodSymbol.IsExtensionMethod)
            {
                foreach (var item in methodSymbol.Locations)
                {
                    context.ReportDiagnostic(Diagnostic.Create(Rule, item));
                }
            }
        }
    }
}
