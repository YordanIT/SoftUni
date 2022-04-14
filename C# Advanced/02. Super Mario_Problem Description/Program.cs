using System;
using System.Linq;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] field = new char[n][];
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();
                field[row] = currRow.ToCharArray();

                if (currRow.Contains('M'))
                {
                    marioRow = row;
                    marioCol = currRow.IndexOf('M');
                }
            }

            string[] command = Console.ReadLine().Split();

            while (lives > 0)
            {
                char move = char.Parse(command[0]);
                int bowserRow = int.Parse(command[1]);
                int bowserCol = int.Parse(command[2]);
                
                field[bowserRow][bowserCol] = 'B';
                lives--;

                if (move == 'W' && marioRow > 0)
                {
                    field[marioRow][marioCol] = '-';
                    marioRow--; 
                }
                else if (move == 'S' && marioRow < n)
                {
                    field[marioRow][marioCol] = '-';
                    marioRow++;
                }
                else if (move == 'A' && marioCol > 0)
                {
                    field[marioRow][marioCol] = '-';
                    marioCol--;
                }
                else if (move == 'D' && marioCol < field[marioRow].Length)
                {
                    field[marioRow][marioCol] = '-';
                    marioCol++;
                }

                if (field[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        field[marioRow][marioCol] = 'X';
                        break;
                    }
                }
                else if (field[marioRow][marioCol] == '-')
                {
                    field[marioRow][marioCol] = 'M';
                }
                else if (field[marioRow][marioCol] == 'P')
                {
                    field[marioRow][marioCol] = '-';
                    break;
                }
                command = Console.ReadLine().Split();
            }

            if (lives > 0)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(field[row]);
            }
        }
    }
}
