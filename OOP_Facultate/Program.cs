using System;

namespace OOP_Facultate
{
    class Stars
    {
        int rows;
        public Stars(int rows)
        {
            this.rows = rows;
        }

        public void DrawStars()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }

        ~Stars()
        {
            Console.WriteLine("Instanta clasei Stars a fost distrusa.");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Stars s = new Stars(5);
            s.DrawStars();
            Console.ReadKey();
        }
    }
}
