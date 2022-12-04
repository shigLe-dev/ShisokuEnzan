namespace ShisokuEnzan.AST.Expressions
{
    internal class PrefixExpression : IExpression
    {
        readonly string op;
        readonly IExpression expression;

        public PrefixExpression(string op, IExpression expression)
        {
            this.op = op;
            this.expression = expression;
        }

        public string ToCode()
        {
            return op + expression.ToCode();
        }
    }
}
