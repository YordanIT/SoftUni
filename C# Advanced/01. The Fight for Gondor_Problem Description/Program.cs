using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> orcs = new Stack<int>();
            int currentPlate = plates.Peek();
            int currentOrc = 0;

            for (int i = 1; i <= N; i++)
            {
                if (!plates.Any())
                {
                    orcs.Pop();
                    orcs.Push(currentOrc);
                    
                    break;
                }
                
                orcs = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
                
                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                currentOrc = orcs.Peek();

                while (plates.Any() && orcs.Any())
                {
                    if (currentPlate > currentOrc)
                    {
                        currentPlate -= currentOrc;
                        orcs.Pop();
                        if (orcs.Any())
                        {
                            currentOrc = orcs.Peek();
                        }
                        
                    }
                    else if (currentPlate == currentOrc)
                    {
                        plates.Dequeue();
                        if (plates.Any())
                        {
                            currentPlate = plates.Peek();
                        }

                        orcs.Pop();
                        if (orcs.Any())
                        {
                            currentOrc = orcs.Peek();
                        }
                    }
                    else if (currentPlate < currentOrc)
                    {
                        currentOrc -= currentPlate;
                        plates.Dequeue();
                        if (plates.Any())
                        {
                            currentPlate = plates.Peek();
                        }
                        
                    }
                }

            }

            if (plates.Any())
            {
                plates.Dequeue();
                plates.Enqueue(currentPlate);
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates.Reverse())}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }            
        }
    }
}
