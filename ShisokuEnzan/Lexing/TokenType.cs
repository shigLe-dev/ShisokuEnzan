namespace ShisokuEnzan.Lexing;

internal enum TokenType
{
    ILLEGAL, // 不正
    EOF, // 終端
    NUMBER, // 数
    PLUS, // +
    MINUS, // -
    REMAINDER, // %
    ASTERISK, // *
    SLASH, // /
    LPAREN, // (
    RPAREN, // )
}