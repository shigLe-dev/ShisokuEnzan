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
            string[] strings = s.Split('.');
            if (strings.Length == 2)
            {
                BigInteger up = BigInteger.Parse(strings[0]);
                BigInteger lo = BigInteger.Parse(strings[1] == "" ? "0" : strings[1]);
                int length = strings[1].Length;
                BigInteger h = BigInteger.Pow(new BigInteger(10), length);

                up *= h;
                num = up + lo;
                deno = h;

                return;
            }
            num = BigInteger.Parse(s);
        }

        public EnzanPoint(long l)
        {
            num = l;
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

        public string ToString(int digit)
        {
            (var up, var lo) = ToRealNumber(digit);
            if (lo == 0) return up.ToString();
            return up.ToString() + "." + lo.ToString();
        }
    }
}


