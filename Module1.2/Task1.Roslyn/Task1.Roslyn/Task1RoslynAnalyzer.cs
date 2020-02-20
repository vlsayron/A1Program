using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Task1.Roslyn
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class RoslynAnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "RoslynAnalyzer";
        public const string Controller = "Controller";
        public const string BaseClass = "System.Web.Mvc.Controller";

        internal static readonly LocalizableString Title =
            new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        internal static readonly LocalizableString MessageFormat =
            new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        internal static readonly LocalizableString Description =
            new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        internal const string Category = "Naming";

        internal static DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(FindBadController, SymbolKind.NamedType);
        }
        public static ImmutableArray<INamedTypeSymbol> GetBaseClasses(INamedTypeSymbol type, INamedTypeSymbol objectType)
        {
            if (type == null || type.TypeKind == TypeKind.Error)
                return ImmutableArray<INamedTypeSymbol>.Empty;

            if (type.BaseType != null && type.BaseType.TypeKind != TypeKind.Error)
                return GetBaseClasses(type.BaseType, objectType).Add(type.BaseType);

            return ImmutableArray<INamedTypeSymbol>.Empty;
        }

        private static void FindBadController(SymbolAnalysisContext context)
        {
            
            var mvcController = context.Compilation.GetTypeByMetadataName(BaseClass);
            var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;
            var baseTypes = GetBaseClasses(namedTypeSymbol, context.Compilation.ObjectType);

            if (baseTypes.Contains(mvcController))
            {
                var name = context.Symbol.Name;
                if (!name.EndsWith(Controller, System.StringComparison.Ordinal))
                {
                    var diagnostic = Diagnostic.Create(Rule, namedTypeSymbol.Locations[0], namedTypeSymbol.Name);
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }
    }

}

