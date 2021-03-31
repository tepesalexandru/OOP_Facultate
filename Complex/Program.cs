using System;
using System.Text;

namespace Complex
{
    class Complex
    {
        public float Real, Imaginary;
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            if (this.Imaginary > 0)
            {
                s.AppendFormat("{0:0.00} + {1:0.00}i", this.Real, this.Imaginary);
            } else
            {
                if (this.Imaginary < 0)
                {
                    s.AppendFormat("{0:0.00} - {1:0.00}i", this.Real, Math.Abs(this.Imaginary));
                } else
                {
                    s.AppendFormat("{0:0.00}", this.Real);
                }
            }
            return s.ToString();
        }
        public Complex()
        {

        }
        public Complex(float Real)
        {
            this.Real = Real;
        }
        public Complex(float Real, float Imaginary)
        {
            this.Real = Real;
            this.Imaginary = Imaginary;
        }
        public static Complex operator + (Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }
        public static Complex operator - (Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }
        public static Complex operator * (Complex a, Complex b)
        {
            return new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
        }
        public static Complex operator ^ (Complex a, int n)
        {
            Complex result = a;
            for (int i = 0; i < n - 1; i++)
            {
                result = result * a;
            }
            return result;
        }
        public void PrintTrigonometricForm()
        {
            double radius = Math.Sqrt(this.Real * this.Real + this.Imaginary * this.Imaginary);
            double thetaInRadians = Math.Atan2(this.Imaginary, this.Real);
            double thetaInDegrees = (180 / Math.PI) * thetaInRadians;
            Console.WriteLine($"x = {String.Format("{0:0.00}", radius)}(cos {String.Format("{0:0.00}", thetaInDegrees)}° + i sin {String.Format("{0:0.00}", thetaInDegrees)}°)");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(-7, -3);
            a.PrintTrigonometricForm();
            Console.ReadKey();
        }
    }
}
