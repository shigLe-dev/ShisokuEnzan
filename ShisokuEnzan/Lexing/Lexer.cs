namespace ShisokuEnzan.Lexing;

internal class Lexer
{
    private readonly string code;
    private char currentChar;
    private char nextChar;
    private int position;

    public Lexer(string code)
    {
        this.code = code;
        ReadChar();
    }

    public Token NextToken()
    {
        // �󔒔�΂�
        SkipWhiteSpace();

        Token token = new Token(TokenType.ILLEGAL, currentChar.ToString());
        switch (currentChar)
        {
            case '+':
                token = new Token(TokenType.PLUS, currentChar.ToString());
                break;
            case '-':
                token = new Token(TokenType.MINUS, currentChar.ToString());
                break;
            case '%':
                token = new Token(TokenType.REMAINDER, currentChar.ToString());
                break;
            case '*':
                token = new Token(TokenType.ASTERISK, currentChar.ToString());
                break;
            case '/':
                token = new Token(TokenType.SLASH, currentChar.ToString());
                break;
            case '(':
                token = new Token(TokenType.LPAREN, currentChar.ToString());
                break;
            case ')':
                token = new Token(TokenType.RPAREN, currentChar.ToString());
                break;
            case (char)0:
                token = new Token(TokenType.EOF, "");
                break;
            default:
                // ����
                if (IsDigit(currentChar))
                {
                    string number = ReadNumber();
                    token = new Token(TokenType.NUMBER, number);
                    break;
                }
                break;
        }

        ReadChar();
        return token;
    }

    private bool IsDigit(char c)
    {
        return '0' <= c && c <= '9';
    }

    private void SkipWhiteSpace()
    {
        while (currentChar == ' '
            || currentChar == '\t'
            || currentChar == '\r'
            || currentChar == '\n') ReadChar();
    }

    private void ReadChar()
    {
        // currentChar���Z�b�g
        if (position >= code.Length) currentChar = (char)0;
        else currentChar = code[position];

        // nextChar���Z�b�g
        if (position + 1 >= code.Length) nextChar = (char)0;
        else nextChar = code[position + 1];

        // position��1�i�߂�
        position++;
    }

    private string ReadNumber()
    {
        string number = currentChar.ToString();
        bool isDecimal = false;

        while (IsDigit(nextChar) || (isDecimal =( !isDecimal && nextChar == '.')))
        {
            number += nextChar;
            ReadChar();
        }

        return number;
    }
}