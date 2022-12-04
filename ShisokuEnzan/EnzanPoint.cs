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

        public (BigInteger up, BigInteger lo) ToRealNumber(int digit)
        {
            BigInteger up;
            BigInteger lo;
            BigInteger d = BigInteger.Pow(10, digit);
            BigInteger r = num * d / deno;

            up = r / d;
            lo = r - up * d;

            return (up, lo);
        }

        public static EnzanPoint operator +(EnzanPoint a, EnzanPoint b)
        {
            return new EnzanPoint(a.num * b.deno + b.num * a.deno, a.deno * b.deno);
        }

        public static EnzanPoint operator -(EnzanPoint a, EnzanPoint b)
        {
            return new EnzanPoint(a.num * b.deno - b.num * a.deno, a.deno * b.deno);
        }

        public static EnzanPoint operator *(EnzanPoint a, EnzanPoint b)
        {
            return new EnzanPoint(a.num * b.num, a.deno * b.deno);
        }

        public static EnzanPoint operator /(EnzanPoint a, EnzanPoint b)
        {
            return new EnzanPoint(a.num * b.deno, a.deno * b.num);
        }

        public static implicit operator float(EnzanPoint a)
        {
            int d = 7;
            (BigInteger up, BigInteger lo) = a.ToRealNumber(d);
            return ((float)up) + ((float)lo / (float)Math.Pow(10, d));
        }

        public static implicit operator double(EnzanPoint a)
        {
            int d = 17;
            (BigInteger up, BigInteger lo) = a.ToRealNumber(d);
            return ((double)up) + ((double)lo / Math.Pow(10, d));
        }
    }
}
