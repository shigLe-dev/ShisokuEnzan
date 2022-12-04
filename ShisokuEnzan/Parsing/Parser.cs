using ShisokuEnzan.AST;
using ShisokuEnzan.AST.Expressions;
using ShisokuEnzan.Lexing;
using System.Text;

namespace ShisokuEnzan.Parsing;

internal class Parser
{
    private Token currentToken;
    private Token nextToken;
    private Precedence currentPrecedence
    {
        get
        {
            if (Precedences.TryGetValue(currentToken.type, out var p))
            {
                return p;
            }

            return Precedence.LOWEST;
        }
    }
    private Precedence nextPrecendence
    {
        get
        {
            if (Precedences.TryGetValue(nextToken.type, out var p))
            {
                return p;
            }

            return Precedence.LOWEST;
        }
    }
    private readonly Lexer lexer;
    private Dictionary<TokenType, Precedence> Precedences = new Dictionary<TokenType, Precedence>()
    {
        {TokenType.PLUS, Precedence.SUM },
        {TokenType.MINUS, Precedence.SUM },
        {TokenType.ASTERISK, Precedence.PRODUCT },
        {TokenType.SLASH, Precedence.PRODUCT },
    };// 優先度
    private Dictionary<TokenType, Func<IExpression>> prefixFunctions; // 前置
    private Dictionary<TokenType, Func<IExpression, IExpression>> infixFunctions; // 中置

    public Parser(Lexer lexer)
    {
        this.lexer = lexer;

        RegisterInfixFunctions();
        RegisterPrefixFunctions();

        currentToken = lexer.NextToken();
        nextToken = lexer.NextToken();
    }

    private void RegisterPrefixFunctions()
    {
        prefixFunctions = new Dictionary<TokenType, Func<IExpression>>
        {
            {TokenType.NUMBER,  ParseNumber},
            {TokenType.MINUS,  ParsePrefixExpression},
            {TokenType.PLUS,  ParsePrefixExpression},
            {TokenType.LPAREN, ParseGroupedExpression }
        };
    }

    private void RegisterInfixFunctions()
    {
        infixFunctions = new Dictionary<TokenType, Func<IExpression, IExpression>>()
        {
            {TokenType.PLUS,  ParseInfixExpression},
            {TokenType.MINUS, ParseInfixExpression},
            {TokenType.ASTERISK,  ParseInfixExpression},
            {TokenType.SLASH, ParseInfixExpression}
        };
    }

    private void ReadToken()
    {
        currentToken = nextToken;
        nextToken = lexer.NextToken();
    }

    public IExpression Parse()
    {
        return ParseExpression(Precedence.LOWEST);
    }

    private IExpression ParseExpression(Precedence precedence)
    {
        prefixFunctions.TryGetValue(currentToken.type, out Func<IExpression>? prefix);
        if (prefix == null) throw new Exception();

        var leftExpression = prefix();

        while (nextToken.type != TokenType.EOF 
            && precedence < nextPrecendence)
        {
            infixFunctions.TryGetValue(nextToken.type, out var infix);
            if (infix == null) return leftExpression;

            ReadToken();
            leftExpression = infix(leftExpression);
        }

        return leftExpression;
    }

    private bool ExpectPeek(TokenType type)
    {
        if (nextToken.type == type)
        {
            ReadToken();
            return true;
        }

        throw new Exception(new StringBuilder()
            .AppendLine(type.ToString())
            .AppendLine(currentToken.literal)
            .AppendLine(nextToken.literal)
            .ToString());
    }

    #region ParsePrefix

    private IExpression ParseNumber()
    {
        return new NumberLiteral(currentToken.literal);
    }

    private IExpression ParsePrefixExpression()
    {
        string op = currentToken.literal;

        ReadToken();

        IExpression expression = ParseExpression(Precedence.PREFIX);
        return new PrefixExpression(op, expression);
    }

    private IExpression ParseGroupedExpression()
    {
        // (の次のやつ
        ReadToken();

        // 中身
        var expression = ParseExpression(Precedence.LOWEST);

        // )
        ExpectPeek(TokenType.RPAREN);

        return expression;
    }

    #endregion

    #region ParseInfix

    private IExpression ParseInfixExpression(IExpression left)
    {
        var p = currentPrecedence;
        var op = currentToken.literal;
        ReadToken();
        return new InfixExpression(op, left, ParseExpression(p));
    }

    #endregion
}