using System;

namespace Matrice
{
    class Matrice
    {
        public int n, m;
        public double[,] values;
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    s += values[i, j] + " ";
                }
                s += '\n';
            }
            return s;
        }
        public Matrice(int n)
        {
            this.n = n;
            this.m = n;
            values = new double[n, m];
        }
        public Matrice(int n, int m)
        {
            this.n = n;
            this.m = m;
            values = new double[n, m];
        }
        public Matrice(int n, double[,] values)
        {
            this.n = n;
            this.m = n;
            this.values = values;
        }
        public Matrice(int n, int m, double[,] values)
        {
            this.n = n;
            this.m = m;
            this.values = values;
        }
        public Matrice Add (Matrice a)
        {
            if (a.n == this.n && a.m == this.m)
            {
                Matrice rez = new Matrice(n, m);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        rez.values[i, j] = this.values[i, j] + a.values[i, j];
                return rez;
            }
            Console.WriteLine("You cannot add the two matrices, they do not have the same dimensions.");
            return null;
        }
        public Matrice Subtract (Matrice a)
        {
            if (a.n == this.n && a.m == this.m)
            {
                Matrice rez = new Matrice(n, m);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        rez.values[i, j] = this.values[i, j] - a.values[i, j];
                return rez;
            }
            Console.WriteLine("You cannot subtract the two matrices, they do not have the same dimensions.");
            return null;
        }
        public Matrice Multiply (Matrice a)
        {
            if (this.m != a.n)
            {
                Console.WriteLine("You cannot multiply the two matrices.");
                return null;
            }
            else
            {
                Matrice rez = new Matrice(this.n, this.m);
                for (int i = 0; i < this.n; i++)
                    for (int j = 0; j < a.m; j++)
                    {
                    rez.values[i, j] = 0;
                        for (int k = 0; k < this.m; k++)
                        rez.values[i, j] += this.values[i, k] * a.values[k, j];
                    }
                return rez;
            }
        }
        public Matrice Power (int k)
        {
            if (this.n != this.m)
            {
                Console.WriteLine("You cannot raise this matrix to a power. It's not a square matrix.");
                return null;
            }
            Matrice rez = new Matrice(this.n, this.m, this.values);
            for (int i = 0; i < k - 1; i++)
            {
                rez = rez.Multiply(this);
            }
            return rez;
        }
        private double det(double[,] a, int n)
        {
            int i, j;
            double d, e, aux;

            if (n == 1)
                return a[0, 0];
            else
            {
                d = 0.0;
                for (j = 0; j < n; j++) 
                {
                   
                    if (((n - 1 - j) % 2 == 1) || (j == n - 1))
                        e = a[n - 1, j];
                    else
                        e = -a[n - 1, j];
                    
                    for (i = 0; i < n - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                    if ((n - 1 + j) % 2 == 0)
                        d += e * det(a, n - 1);
                    else
                        d -= e * det(a, n - 1);

                    
                    for (i = 0; i < n - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                }
                return d;
            }
        }
        public Matrice Inverse()
        {
            if (this.n == this.m)
            {
                double d = this.det(this.values, this.n);
                if (d != 0)
                {
                    Matrice rez = new Matrice(this.n);
                    Matrice temp = new Matrice(this.n);
                    
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            temp.values[i, j] = this.values[j, i];
                    double aux;
                    int semn;
                   
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.values[i, k];
                                temp.values[i, k] = temp.values[n - 1, k];
                                temp.values[n - 1, k] = aux;
                            }
                            
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.values[k, j];
                                temp.values[k, j] = temp.values[k, n - 1];
                                temp.values[k, n - 1] = aux;
                            }
                            
                            semn = 1;
                            if (((n - 1 - i) % 2 == 0) && (i != n - 1))
                                semn *= -1;
                            if (((n - 1 - j) % 2 == 0) && (j != n - 1))
                                semn *= -1;
                            if ((i + j) % 2 == 1)
                                semn *= -1;
                            rez.values[i, j] = semn * det(temp.values, n - 1);
                            
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.values[i, k];
                                temp.values[i, k] = temp.values[n - 1, k];
                                temp.values[n - 1, k] = aux;
                            }
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.values[k, j];
                                temp.values[k, j] = temp.values[k, n - 1];
                                temp.values[k, n - 1] = aux;
                            }
                        }
                    
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            rez.values[i, j] /= d;
                    return rez;
                }
                Console.WriteLine("This matrix is not inversable. The determinant is zero.");
                return null;
            }
            Console.WriteLine("You cannot inverse this matrix, it's not a square matrix.");
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double[,] aValues = new double[2, 2] 
            { 
              { 1, 2 },
              { 3, 4 } 
            };
            double[,] bValues = new double[2, 2]
            {
              { 5, 6 },
              { 7, 8 }
            };
            Matrice a = new Matrice(2, aValues);
            Matrice b = new Matrice(2, bValues);
            Console.WriteLine(a.Add(b));
            Console.WriteLine(a.Multiply(b));
            Console.WriteLine(a.Power(4));
            Console.WriteLine(a.Inverse());
        }
    }
}
