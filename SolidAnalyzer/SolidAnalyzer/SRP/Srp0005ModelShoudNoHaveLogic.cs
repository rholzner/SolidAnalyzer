using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace SolidAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Srp0005ModelShoudNoHaveLogic : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "Srp0005";
        //http://source.roslyn.io/#Microsoft.CodeAnalysis/Symbols/IModuleSymbol.cs
        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.Srp0005Title), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.Srp0005MessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.Srp0005Description), Resources.ResourceManager, typeof(Resources));
        private const string Category = "SOLID";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterCodeBlockAction(AnalyzeSymbol);
        }

        private static void AnalyzeSymbol(CodeBlockAnalysisContext context)
        {
            if (context.OwningSymbol.Name.StartsWith("get_"))
            {
                var prop = context.CodeBlock.DescendantNodes().OfType<ReturnStatementSyntax>().FirstOrDefault();
                context.ReportDiagnostic(Diagnostic.Create(Rule,prop.GetLocation()));
            }

            if (context.OwningSymbol.Name.StartsWith("set_"))
            {
                var refrens = context.CodeBlock.DescendantNodes().OfType<ReferenceDirectiveTriviaSyntax>();
                foreach (var item in refrens)
                {
                    context.ReportDiagnostic(Diagnostic.Create(Rule, item.GetLocation()));
                }
            }
        }

    }
}
