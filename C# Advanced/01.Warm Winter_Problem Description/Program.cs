using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sets = new List<int>();
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            while (hats.Any() && scarfs.Any())
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();

                if (currentHat == currentScarf)
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(++currentScarf);
                }
                else if (currentScarf > currentHat)
                {
                    hats.Pop();
                    if (hats.Any())
                    {
                        currentHat = hats.Peek();
                    }
                }
                else
                {
                    int newSet = currentHat + currentScarf;
                    sets.Add(newSet);
                    hats.Pop();
                    scarfs.Dequeue();
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
