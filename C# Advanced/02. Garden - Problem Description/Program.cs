using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NM = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = NM[0];
            int m = NM[1];
            int[,] field = new int[n, m];

            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                int row = int.Parse(command[0].ToString());
                int col = int.Parse(command[2].ToString());

                if (row < 0 || row >= n || col < 0 || col >= m)
                {
                    Console.WriteLine("Invalid coordinates.");
                    command = Console.ReadLine();
                    continue;
                }

                for (int i = 0; i < m; i++)
                {
                    if (field[row, i] != 0)
                    {
                        field[row, i]++;
                    }
                    else
                    {
                        field[row, i] = 1;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    if (field[i, col] != 0)
                    {
                        field[i, col]++;
                    }
                    else
                    {
                        field[i, col] = 1;
                    }
                }

                field[row, col] = 1;
                command = Console.ReadLine();
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{field[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}