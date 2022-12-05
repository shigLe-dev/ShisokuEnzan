using ShisokuEnzan.Evaluating;
using ShisokuEnzan.Lexing;
using ShisokuEnzan.Parsing;
namespace ShisokuEnzan;

public static class Enzan
{
    public static double Calc(string code)
    {
        Lexer lexer = new Lexer(code);
        Parser parser = new Parser(lexer);
        Evaluator eval = new Evaluator(parser.Parse());

        return eval.Eval();
    }
}
