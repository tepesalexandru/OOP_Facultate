using System;

namespace Rational
{
    class Rational
    {
        public int Numerator;
        public int Denominator;
        public Rational()
        {

        }
        public Rational(int Numerator)
        {
            this.Numerator = Numerator;
            this.Denominator = 1;
        }
        public Rational(int Numerator, int Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
            Simplify();
        }
        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        public void Simplify()
        {
            int gcd = GCD(this.Numerator, this.Denominator);
            this.Numerator /= gcd;
            this.Denominator /= gcd;
        }
        private double Value()
        {
            return (double)this.Numerator / (double)this.Denominator;
        }
        public static Rational operator + (Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Denominator + a.Denominator * b.Numerator, a.Denominator * b.Denominator);
        }
        public static Rational operator - (Rational a, Rational b)
        {
            b.Numerator *= -1;
            return a + b;
        }
        public static Rational operator * (Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }
        public static Rational operator ^ (Rational a, int n)
        {
            Rational result = a;
            for (int i = 0; i < n - 1; i++)
            {
                result *= a;
            }
            return result;
        }
        public static bool operator < (Rational a, Rational b)
        {
            return a.Value() < b.Value();
        }
        public static bool operator > (Rational a, Rational b)
        {
            return a.Value() > b.Value();
        }
        public static bool operator <= (Rational a, Rational b)
        {
            return a.Value() <= b.Value();
        }
        public static bool operator >= (Rational a, Rational b)
        {
            return a.Value() >= b.Value();
        }
        public static bool operator == (Rational a, Rational b)
        {
            return a.Value() == b.Value();
        }
        public static bool operator != (Rational a, Rational b)
        {
            return a.Value() != b.Value();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rational a = new Rational(2, 5);
            Rational b = new Rational(4, 8);
            bool equal = a < b;
            Console.WriteLine("" + equal);
        }
    }
}
