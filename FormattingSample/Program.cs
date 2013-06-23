namespace FormattingSample
{
    using Roslyn.Compilers.CSharp;
    using Roslyn.Services;
    using Roslyn.Services.Formatting;

    class Program
    {
        static void Main(string[] args)
        {            
            var tree = SyntaxTree.ParseFile("Resources/Sample.cs");

            CompilationUnitSyntax root;
            tree.TryGetRoot(out root);

            var formattedCode = new CodeBeautifier().Visit(root).GetText().ToString();

            //var formattedCode = root.Format(FormattingOptions.GetDefaultOptions()).GetFormattedRoot().GetText().ToString();
        }
    }
}
