using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] area = new char[n,n];
            int food = 0;
            int sRow = 0;
            int sCol = 0;
            int b1Row = 0;
            int b1Col = 0;
            int b2Row = 0;
            int b2Col = 0;
            int timesB = 0;

            for (int row = 0; row < n; row++)
            {
                string currCol = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    area[row, col] = currCol[col];
                    if (currCol[col] == 'S')
                    {
                        sRow = row;
                        sCol = col;
                    }
                    else if (currCol[col] == 'B' && timesB == 0)
                    {
                        b1Row = row;
                        b1Col = col;
                        timesB++;
                    }
                    else if (currCol[col] == 'B' && timesB > 0)
                    {
                        b2Row = row;
                        b2Col = col;
                    }
                }
            }

            while (food < 10)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    area[sRow, sCol] = '.';
                    sRow--;
                }
                else if (command == "down")
                {
                    area[sRow, sCol] = '.';
                    sRow++;
                }
                else if(command == "left")
                {
                    area[sRow, sCol] = '.';
                    sCol--;
                }
                else if (command == "right")
                {
                    area[sRow, sCol] = '.';
                    sCol++;
                }

                if (sRow < 0 || sRow >= n || sCol < 0 || sCol >= n)
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {food}");
                    break;
                }

                if (area[sRow,sCol] == 'B')
                {
                    if (sRow == b1Row && sCol == b1Col)
                    {
                        sRow = b2Row;
                        sCol = b2Col;
                        area[b1Row, b1Col] = '.';
                    }
                    else if (sRow == b2Row && sCol == b2Col)
                    {
                        sRow = b1Row;
                        sCol = b1Col;
                        area[b2Row, b2Col] = '.';
                    }

                    area[sRow, sCol] = 'S';
                }
                else if (area[sRow,sCol] == '*')
                {
                    food++;
                }
                else
                {
                    area[sRow, sCol] = 'S';
                }

            }

            if (food >= 10)
            {
                area[sRow, sCol] = 'S';
                Console.WriteLine($"You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {food}");
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(area[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
