using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace SolidAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Ocp0001DoNotNullCheck : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "Srp0004";
        //https://joshvarty.com/2015/03/24/learn-roslyn-now-control-flow-analysis/
        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.Srp0004Title), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.Srp0004MessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.Srp0004Description), Resources.ResourceManager, typeof(Resources));
        private const string Category = "SOLID";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterCodeBlockAction(AnalyzeSymbol);
        }

        private static void AnalyzeSymbol(CodeBlockAnalysisContext context)
        {
            // TODO: Replace the following code with your own analysis, generating Diagnostic objects for any issues you find
            var ifs = context.CodeBlock.DescendantNodes().OfType<SwitchStatementSyntax>();
            foreach (var ifstament in ifs)
            {
                foreach (var nestedif in ifstament.DescendantNodes().OfType<IfStatementSyntax>())
                {
                    context.ReportDiagnostic(Diagnostic.Create(Rule, nestedif.GetLocation()));
                }
            }
        }
    }
}
