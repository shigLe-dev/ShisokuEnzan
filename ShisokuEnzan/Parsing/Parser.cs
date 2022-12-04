using ShisokuEnzan.Lexing;

namespace ShisokuEnzan.Parsing;

internal class Parser
{
    private Token currentToken;
    private Token nextToken;
    private readonly Lexer lexer;

    public Parser(Lexer lexer)
    {
        this.lexer = lexer;

        currentToken = lexer.NextToken();
        nextToken = lexer.NextToken();
    }
}