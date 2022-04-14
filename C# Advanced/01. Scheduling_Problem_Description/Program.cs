using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int taskToBeKilled = int.Parse(Console.ReadLine());
            int curentThread = 0;

            while (true)
            {
                int currentTask = tasks.Peek();
                curentThread = threads.Peek();

                if (currentTask == taskToBeKilled)
                {
                    break;
                }

                if (curentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();

                    
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {curentThread} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
