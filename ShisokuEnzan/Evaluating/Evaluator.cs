using ShisokuEnzan.AST;
using ShisokuEnzan.AST.Expressions;

namespace ShisokuEnzan.Evaluating
{
    internal class Evaluator
    {
        IExpression rootExpression;

        public Evaluator(IExpression rootExpression)
        {
            this.rootExpression = rootExpression;
        }

        public EnzanPoint Eval()
        {
            return EvalExpression(rootExpression);
        }

        private EnzanPoint EvalExpression(IExpression expression)
        {
            switch (expression)
            {
                case InfixExpression infixExpression:
                    return EvalInfixExpression(infixExpression);
                case NumberLiteral numberLiteral:
                    return EvalNumberLiteral(numberLiteral);
                case PrefixExpression prefixExpression:
                    return EvalPrefixExpression(prefixExpression);
                default:
                    return new EnzanPoint();
            }
        }

        private EnzanPoint EvalInfixExpression(InfixExpression infixExpression)
        {
            EnzanPoint left = EvalExpression(infixExpression.leftExpression);
            EnzanPoint right = EvalExpression(infixExpression.rightExpression);

            switch (infixExpression.op)
            {
                case "+":
                    return left + right;
                case "-":
                    return left - right;
                case "*":
                    return left * right;
                case "/":
                    return left / right;
                default:
                    throw new Exception();
            }
        }

        private EnzanPoint EvalNumberLiteral(NumberLiteral numberLiteral)
        {
            return new EnzanPoint(numberLiteral.literal);
        }

        private EnzanPoint EvalPrefixExpression(PrefixExpression prefixExpression)
        {
            EnzanPoint right = EvalExpression(prefixExpression.expression);

            switch (prefixExpression.op)
            {
                case "+":
                    return right;
                case "-":
                    return right * new EnzanPoint(-1);
                default:
                    throw new Exception();
            }
        }
    }
}
