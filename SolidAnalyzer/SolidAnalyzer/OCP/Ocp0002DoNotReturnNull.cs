using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace SolidAnalyzer.OCP
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Ocp0002DoNotReturnNull : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "Ocp0002";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.Ocp0002Title), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.Ocp0002MessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.Ocp0002Description), Resources.ResourceManager, typeof(Resources));
        private const string Category = "SOLID";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Info, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterCodeBlockAction(AnalyzeSymbol);
        }

        private static void AnalyzeSymbol(CodeBlockAnalysisContext context)
        {
            // TODO: Replace the following code with your own analysis, generating Diagnostic objects for any issues you find
            var returns = context.CodeBlock.DescendantNodes().OfType<ReturnStatementSyntax>();
            foreach (var r in returns)
            {
                foreach (var item in r.DescendantTokens().Where(x => x.IsKind(SyntaxKind.NullKeyword)))
                {
                    context.ReportDiagnostic(Diagnostic.Create(Rule, item.GetLocation()));
                }
            }

        }
    }
}
