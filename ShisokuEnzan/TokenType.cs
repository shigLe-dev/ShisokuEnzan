namespace ShisokuEnzan;

internal enum TokenType
{
    ILLEGAL, // 不正
    EOF, // 終端
    NUMBER, // 数
    PLUS, // +
    MINUS, // -
    ASTERISK, // *
    SLASH, // /
    LPAREN, // (
    RPAREN, // )
}