namespace ShisokuEnzan.AST.Expressions
{
    internal class InfixExpression : IExpression
    {
        readonly string op;
        readonly IExpression leftExpression;
        readonly IExpression rightExpression;

        public InfixExpression(string op, IExpression leftExpression, IExpression rightExpression)
        {
            this.op = op;
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public string ToCode()
        {
            return leftExpression.ToCode() + op + rightExpression.ToCode();
        }
    }
}
