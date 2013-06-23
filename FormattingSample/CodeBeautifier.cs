namespace FormattingSample
{
    using Roslyn.Compilers.CSharp;

    public class CodeBeautifier : SyntaxRewriter
    {
        public override SyntaxToken VisitToken(SyntaxToken token)
        {
            switch (token.Kind)
            {
                case SyntaxKind.SemicolonToken:

                    if (token.GetPreviousToken().Kind == SyntaxKind.CloseBraceToken ||
                       token.GetPreviousToken().Kind == SyntaxKind.CloseParenToken)
                    {
                        return token
                        .WithLeadingTrivia()
                        .WithTrailingTrivia(Syntax.ElasticCarriageReturnLineFeed);
                    }

                    break;

                case SyntaxKind.CloseBraceToken:

                    if (token.GetNextToken().Kind == SyntaxKind.CloseParenToken ||
                       token.GetNextToken().Kind == SyntaxKind.SemicolonToken)
                    {
                        return token
                        .WithTrailingTrivia();
                    }

                    break;

                case SyntaxKind.CloseParenToken:

                    if (token.GetPreviousToken().Kind == SyntaxKind.CloseBraceToken)
                    {
                        return token
                        .WithLeadingTrivia();
                    }

                    break;
            }

            return token;
        }
    }
}
