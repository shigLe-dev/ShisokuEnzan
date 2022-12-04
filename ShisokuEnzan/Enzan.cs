namespace ShisokuEnzan;

public static class Enzan
{
    public static double Calc(string code)
    {
        Lexer lexer = new Lexer(code);

        Token token = lexer.NextToken();
        while (token.type != TokenType.EOF)
        {
            Console.WriteLine(token.literal + " : " + token.type);
            token = lexer.NextToken();
        }

        return 0;
    }
}
