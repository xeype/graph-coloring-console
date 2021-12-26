using System;

namespace Coursework
{
    class Program
    {
        static void Main(string[] args)
        {
            // int n;
            // Console.WriteLine("Please enter matrix size: ");
            // n = Int32.Parse(Console.ReadLine());
            // int[,] matrix = new int[n, n];
            //
            // for (int i = 0; i < n; i++)
            // {
            //     for (int j = 0; j < n; j++)
            //     {
            //         matrix[i, j] = Int32.Parse(Console.ReadLine());
            //     }
            // }
            //
            // for (int i = 0; i < n; i++)
            // {
            //     for (int j = 0; j < n; j++)
            //     {
            //         Console.Write("{0}\t", matrix[i, j]);
            //     }
            //
            //     Console.WriteLine();
            // }

            int[,] matrix = new int[,] {{1, 1, 0, 0}, {1, 0, 1, 1}, {0, 0, 0, 1}, {0, 1, 1, 0}};


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((matrix[i, j] == 1) || (matrix[j, i] == 1))
                    {
                        Console.WriteLine(j);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}