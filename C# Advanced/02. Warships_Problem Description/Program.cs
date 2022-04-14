using System;
using System.Linq;

namespace WarShip
{
    class Program
    {
        static void Main(string[] args)
        {
            int player1 = 0;
            int player2 = 0;
            
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n,n];
            int[] attacks = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray(); 

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = currentRow[col];
                    
                    if (field[row,col] == '<')
                    {
                        player1++;
                    }
                    else if (field[row,col] == '>')
                    {
                        player2++;
                    }
                }
            }

            int totalShips = player1 + player2;

            for (int i = 0; i < attacks.Length - 1; i += 1)
            {
                int[] coordinates = { attacks[i], attacks[i + 1] };
                
                if (coordinates[0] < 0 || coordinates[1] < 0 || coordinates[0] >= n || coordinates[1] >= n)
                {
                    continue;
                }

                int row = coordinates[0];
                int col = coordinates[1];

                if (field[coordinates[0], coordinates[1]] == '#')
                {
                    if (row - 1 >= 0) //&& (field[x - 1, y] == '<' || field[x - 1, y] == '>'))
                    {
                        if (field[row - 1, col] == '<')
                        {
                            player1--;
                            field[row - 1, col] = 'X';
                        }
                        else if (field[row - 1, col] == '>')
                        {
                            player2--;
                            field[row - 1, col] = 'X';
                        }

                        if (col - 1 >= 0) //&& (field[x - 1, y - 1] == '<' || field[x - 1, y - 1] == '>'))
                        {
                            if (field[row - 1, col - 1] == '<')
                            {
                                player1--;
                                field[row - 1, col - 1] = 'X';
                            }
                            else if (field[row - 1, col - 1] == '>')
                            {
                                player2--;
                                field[row - 1, col - 1] = 'X';
                            }
                        }

                        if (col + 1 >= 0) //&& (field[x - 1, y + 1] == '<' || field[x - 1, y + 1] == '>'))
                        {
                            if (field[row - 1, col + 1] == '<')
                            {
                                player1--;
                                field[row - 1, col + 1] = 'X';
                            }
                            else if (field[row - 1, col + 1] == '>')
                            {
                                player2--;
                                field[row - 1, col + 1] = 'X';
                            }
                        }
                    }

                    if (row + 1 < n) //&& (field[x + 1, y] == '<' || field[x + 1, y] == '>'))
                    {
                        if (field[row + 1, col] == '<')
                        {
                            player1--;
                            field[row + 1, col] = 'X';
                        }
                        else if (field[row + 1, col] == '>')
                        {
                            player2--;
                            field[row + 1, col] = 'X';
                        }

                        if (col - 1 >= 0) //&& (field[x + 1, y - 1] == '<' || field[x + 1, y - 1] == '>'))
                        {
                            if (field[row + 1, col - 1] == '<')
                            {
                                player1--;
                                field[row - +1, col - 1] = 'X';
                            }
                            else if (field[row + 1, col - 1] == '>')
                            {
                                player2--;
                                field[row - +1, col - 1] = 'X';
                            }
                        }

                        if (col + 1 >= 0) //&& (field[x + 1, y + 1] == '<' || field[x + 1, y + 1] == '>'))
                        {
                            if (field[row + 1, col + 1] == '<')
                            {
                                player1--;
                                field[row + 1, col + 1] = 'X';
                            }
                            else if (field[row + 1, col + 1] == '>')
                            {
                                player2--;
                                field[row + 1, col + 1] = 'X';
                            }
                        }
                    }

                    if (col - 1 >= 0) //&& (field[x, y - 1] == '<' || field[x, y - 1] == '>'))
                    {
                        if (field[row, col - 1] == '<')
                        {
                            player1--;
                            field[row, col - 1] = 'X';
                        }
                        if (field[row, col - 1] == '>')
                        {
                            player2--;
                            field[row, col - 1] = 'X';
                        }

                    }

                    if (col + 1 < n) //&& (field[x, y + 1] == '<' || field[x, y + 1] == '>'))
                    {
                        if (field[row, col + 1] == '<')
                        {
                            player1--;
                            field[row, col + 1] = 'X';
                        }
                        if (field[row, col + 1] == '>')
                        {
                            player2--;
                            field[row, col + 1] = 'X';
                        }
                    }
                }
                else if (field[row, col] == '<')
                {
                    player1--;
                    field[row, col] = 'X';

                    if (player1 == 0)
                    {
                        break;
                    }
                }
                else if (field[row, col] == '>')
                {
                    player2--;
                    field[row, col] = 'X';

                    if (player2 == 0)
                    {
                        break;
                    }
                }
            }

            if (player1 > 0 && player2 > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {player1} ships left. Player Two has {player2} ships left.");
            }
            else if (player1 > 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShips - player1 - player2} ships have been sunk in the battle.");
            }
            else if (player2 > 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShips - player1 - player2} ships have been sunk in the battle.");
            }

            /*
             Console.WriteLine("-----------------------------");
            for (int row = 0; row < n; row++)
            {
                //char[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    //field[row, col] = currentRow[col];
                    Console.Write($"{field[row, col]} ");
                }
                Console.WriteLine();
            }
            */
        }
    }
}
