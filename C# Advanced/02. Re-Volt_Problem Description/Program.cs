using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandNums = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int f_LastRow = 0;
            int f_LastCol = 0;
            int F_Row = 0;
            int F_Col = 0;

            // Read matrix
            for (int i = 0; i < n; i++)
            {
                string currentCol = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = currentCol[j];
                    if (field[i,j] == 'f')
                    {
                        f_LastRow = i;
                        f_LastCol = j;
                    }
                    else if (field[i,j] == 'F')
                    {
                        F_Row = i;
                        F_Col = j;
                    }
                }
            }

            int f_Row = f_LastRow;
            int f_Col = f_LastCol;

            string movement = Console.ReadLine();

            for (int i = 0; i < commandNums; i++)
            {
                f_LastRow = f_Row;
                f_LastCol = f_Col;

                //Assign new 'f' position
                if (movement == "up")
                {
                    f_Row--;
                }
                else if (movement == "down")
                {
                    f_Row++;
                }
                else if (movement == "left")
                {
                    f_Col--;
                }
                else if (movement == "right")
                {
                    f_Col++;
                }

                //Check if 'f' is out of field && asaign new 'f' possition if it is out
                if (f_Row < 0)
                {
                    f_Row = n - 1;
                }
                else if (f_Row >= n)
                {
                    f_Row = 0;
                }
                else if (f_Col < 0)
                {
                    f_Col = n - 1;
                }
                else if (f_Col >= n)
                {
                    f_Col = 0;
                }

                //Check for obstacles on the field
                if (field[f_Row, f_Col] == 'F')
                {
                    field[f_LastRow, f_LastCol] = '-';
                    field[f_Row, f_Col] = 'f';

                    Console.WriteLine("Player won!");
                    break;
                }
                else if (field[f_Row, f_Col] == 'T')
                {
                    f_Row = f_LastRow;
                    f_Col = f_LastCol;
                }
                else if (field[f_Row, f_Col] == 'B')
                {
                    field[f_LastRow, f_LastCol] = '-';
                    commandNums++;
                    continue;
                }
                else
                {
                    if (field[f_LastRow, f_LastCol] == 'B')
                    {
                        field[f_Row, f_Col] = 'f';
                    }
                    else
                    {
                        field[f_LastRow, f_LastCol] = '-';
                        field[f_Row, f_Col] = 'f';
                    }
                }

                if (i == commandNums-1)
                {
                    break;
                }
                movement = Console.ReadLine();
            }

            if (field[F_Row,F_Col] == 'F')
            {
                Console.WriteLine("Player lost!");
            }

            //Write matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
