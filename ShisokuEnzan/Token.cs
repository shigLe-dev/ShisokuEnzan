namespace ShisokuEnzan;

internal class Token
{
    public readonly TokenType type;
    public readonly string literal;

    public Token(TokenType type, string literal)
    {
        this.type = type;
        this.literal = literal;
    }
}