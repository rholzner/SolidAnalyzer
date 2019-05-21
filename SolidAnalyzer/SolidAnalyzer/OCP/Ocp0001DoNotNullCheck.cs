using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace SolidAnalyzer.OCP
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Ocp0001DoNotNullCheck : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "Ocp0001";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.Ocp0001Title), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.Ocp0001MessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.Ocp0001Description), Resources.ResourceManager, typeof(Resources));
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
            var ifs = context.CodeBlock.DescendantNodes().OfType<IfStatementSyntax>();
            foreach (var ifstament in ifs)
            {
                if (ifstament.Condition is null)
                {
                    continue;
                }

                if (ifstament.Condition.IsKind(SyntaxKind.NotEqualsExpression) || ifstament.Condition.IsKind(SyntaxKind.EqualsExpression) || ifstament.Condition.IsKind(SyntaxKind.IsExpression))
                {
                    var binaryExpression = ifstament.Condition as BinaryExpressionSyntax;

                    if (binaryExpression == null)
                        return;
                    var left = binaryExpression.Left as LiteralExpressionSyntax;
                    var right = binaryExpression.Right as LiteralExpressionSyntax;

                    if (left != null && left.IsKind(SyntaxKind.NullLiteralExpression))
                    {
                        context.ReportDiagnostic(Diagnostic.Create(Rule, ifstament.GetLocation()));

                    }
                    else if (right != null && right.IsKind(SyntaxKind.NullLiteralExpression))
                    {
                        context.ReportDiagnostic(Diagnostic.Create(Rule, ifstament.GetLocation()));
                    }


                }
            }
        }
    }
}
