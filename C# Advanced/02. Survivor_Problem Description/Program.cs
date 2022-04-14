using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] beach = new char[n][];

            for (int roww = 0; roww < n; roww++)
            {
                char[] currCol= Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                beach[roww] = currCol;
            }

            int myTokens = 0;
            int opponentTokens = 0;
            int opponentMoves = 0;

            string[] command = Console.ReadLine().Split();
            int row = 0;
            int col = 0;

            while (true)
            {
                if (command[0] == "Gong")
                {
                    break;
                }
                else if (opponentMoves == 0)
                {
                    row = int.Parse(command[1]);
                    col = int.Parse(command[2]);
                }
                
                if (row < 0 || row >= n)
                {
                    command = Console.ReadLine().Split();
                  
                    continue;
                }
                else if (col < 0 || col >= beach[row].Length)
                {
                    command = Console.ReadLine().Split();

                    continue;
                }
               
                if (command[0] == "Find")
                {
                    if (beach[row][col] == 'T')
                    {
                        beach[row][col] = '-';
                        myTokens++;
                    }
                }
                else if (command[0] == "Opponent")
                {
                    if (beach[row][col] == 'T')
                    {
                        beach[row][col] = '-';
                        opponentTokens++;
                    }

                    if (command[3] == "up")
                    {
                        row--;
                    }
                    else if (command[3] == "down")
                    {
                        row++;
                    }
                    else if (command[3] == "left")
                    {
                        col--;
                    }
                    else if (command[3] == "right")
                    {
                        col++;
                    }

                    if (opponentMoves == 3)
                    {
                        opponentMoves = 0;
                    }
                    else
                    {
                        opponentMoves++;
                        continue;
                    }
                }

                command = Console.ReadLine().Split();               
            }

            for (int roww = 0; roww < n; roww++)
            {
                Console.WriteLine(string.Join(' ', beach[roww]));
            }

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
    }
}
