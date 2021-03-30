using System;

namespace Complex
{
    class Complex
    {
        public float Real, Imaginary;
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
            Console.WriteLine($"x = {radius}(cos {thetaInDegrees}° + i sin {thetaInDegrees}°)");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(-7);
            Complex b = new Complex(1, 1);
            Complex c = a * b;
            Complex d = a ^ 5;
            a.PrintTrigonometricForm();
            Console.ReadKey();
        }
    }
}
