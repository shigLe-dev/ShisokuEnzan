using System.Numerics;

namespace ShisokuEnzan
{
    public struct EnzanPoint
    {
        public readonly BigInteger num;
        public readonly BigInteger deno = BigInteger.One;

        public EnzanPoint()
        {
            num = BigInteger.Zero;
        }

        public EnzanPoint(BigInteger num, BigInteger deno)
        {
            this.num = num;
            this.deno = deno;
        }

        public EnzanPoint(string s)
        {
            num = BigInteger.Parse(s);
        }

        public static EnzanPoint operator +(EnzanPoint a, EnzanPoint b)
        {
            return new EnzanPoint(a.num * b.deno + b.num * a.deno, a.deno * b.deno);
        }

        public static EnzanPoint operator- (EnzanPoint a , EnzanPoint b)
        {
            return new EnzanPoint(a.num * b.deno - b.num * a.deno, a.deno * b.deno);
        }

        public static EnzanPoint operator* (EnzanPoint a, EnzanPoint b)
        {
            return new EnzanPoint(a.num * b.num, a.deno * b.deno);
        }

        public static EnzanPoint operator/ (EnzanPoint a, EnzanPoint b)
        {
            return new EnzanPoint(a.num * b.deno, a.deno * b.num);
        }
    }
}
