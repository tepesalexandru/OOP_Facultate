using System;
using System.Collections.Generic;

namespace NumarMare
{
    class NumarMare
    {
        public List<int> digits = new List<int>();
        public override string ToString()
        {
            string s = "";
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                s += digits[i];
            }
            return s;
        }
        public NumarMare()
        {

        }
        public NumarMare(int k)
        {
            do
            {
                digits.Add(k % 10);
                k /= 10;
            } while (k > 0);
        }
        public NumarMare(List<int> newDigits)
        {
            digits.AddRange(newDigits);
        }
        public static NumarMare operator + (NumarMare a, NumarMare b)
        {
            NumarMare sum = new NumarMare();
            int index = 0;
            while (index < a.digits.Count && index < b.digits.Count)
            {
                int newDigit = a.digits[index] + b.digits[index];
                sum.digits.Add(newDigit);
                index++;
            }
            while (index < a.digits.Count)
            {
                int newDigit = a.digits[index];
                sum.digits.Add(newDigit);
                index++;
            }
            while (index < b.digits.Count)
            {
                int newDigit = b.digits[index];
                sum.digits.Add(newDigit);
                index++;
            }
            index = 0;
            while (index < sum.digits.Count)
            {
                int remainder = sum.digits[index] / 10;
                sum.digits[index] %= 10;
                if (remainder > 0)
                {
                    if (index + 1 >= sum.digits.Count)
                    {
                        sum.digits.Add(0);
                    }
                    sum.digits[index + 1] += remainder;
                }
                index++;
            }
            return sum;
        }
        public static NumarMare operator * (NumarMare a, NumarMare b)
        {
            NumarMare product = new NumarMare();
            for (int i = 0; i < b.digits.Count; i++)
            {
                for (int j = 0; j < a.digits.Count; j++)
                {
                    int integerProduct = b.digits[i] * a.digits[j];
                    if (i + j >= product.digits.Count) product.digits.Add(0);
                    product.digits[i + j] += integerProduct;
                }
            }
            int index = 0;
            while (index < product.digits.Count)
            {
                int remainder = product.digits[index] / 10;
                product.digits[index] %= 10;
                if (index + 1 >= product.digits.Count && remainder > 0)
                {
                    product.digits.Add(0);
                    
                }
                if (remainder > 0)
                {
                    product.digits[index + 1] += remainder;
                }
                index++;
            }
            return product;
        }
    }
    class Program
    {
        static NumarMare NthFibonacciNumber(int n)
        {
            NumarMare a = new NumarMare(new List<int> { 1 });
            NumarMare b = new NumarMare(new List<int> { 1 });
            NumarMare c = new NumarMare();
            if (n <= 2) return a;
            for (int i = 3; i <= n; i++)
            {
                c = a + b;
                a = new NumarMare(b.digits);
                b = new NumarMare(c.digits);
            }
            return c;
        }
        static NumarMare BigFactorial(int n)
        {
            NumarMare factorial = new NumarMare(1);
            for (int i = 2; i <= n; i++)
            {
                factorial = factorial * new NumarMare(i);
            }
            return factorial;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(NthFibonacciNumber(100));
            Console.WriteLine(BigFactorial(1000));
        }
    }
}
