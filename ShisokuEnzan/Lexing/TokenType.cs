namespace ShisokuEnzan.Lexing;

internal enum TokenType
{
    ILLEGAL, // �s��
    EOF, // �I�[
    NUMBER, // ��
    PLUS, // +
    MINUS, // -
    REMAINDER, // %
    ASTERISK, // *
    SLASH, // /
    LPAREN, // (
    RPAREN, // )
}