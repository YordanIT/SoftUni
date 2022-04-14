using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> foods = new Dictionary<string, int>
            { { "Dipping sauce", 0 }, { "Green salad", 0 }, { "Chocolate cake", 0}, { "Lobster", 0} };
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currIngeriend = ingredients.Peek();
                int currFreshness = freshness.Peek();
                
                if (currIngeriend == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                if (currIngeriend * currFreshness == 150)
                {
                    foods["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (currIngeriend * currFreshness == 250)
                {
                    foods["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (currIngeriend * currFreshness == 300)
                {
                    foods["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (currIngeriend * currFreshness == 400)
                {
                    foods["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    currIngeriend += 5;
                    ingredients.Dequeue();
                    ingredients.Enqueue(currIngeriend);
                }
            }

            if (foods.ContainsValue(0))
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            else
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var food in foods.Where(f => f.Value > 0).OrderBy(f => f.Key))
            {
                Console.WriteLine($" # {food.Key} --> {food.Value}");
            }
        }
    }
}