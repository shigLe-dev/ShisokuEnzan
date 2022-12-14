namespace ShisokuEnzan.AST.Expressions
{
    internal class NumberLiteral : IExpression
    {
        public readonly string literal;

        public NumberLiteral(string literal)
        {
            this.literal = literal;
        }

        public string ToCode()
        {
            return literal;
        }
    }
}
