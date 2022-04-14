using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> box1 = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> box2 = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int loot = 0;

            while (box1.Count > 0 && box2.Count > 0)
            {
                int item1 = box1.Peek();
                int item2 = box2.Peek();

                if ((item1 + item2) % 2 == 0)
                {
                    loot += item1 + item2;
                    box1.Dequeue();
                    box2.Pop();
                    continue;
                }

                int moveItem = box2.Pop();
                box1.Enqueue(moveItem);
            }

            if (box1.Count <= 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (loot >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {loot}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {loot}");
            }
        }
    }
}
