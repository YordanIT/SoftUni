using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> foods = new Dictionary<string, int> { { "Bread", 0 }, { "Cake", 0 }, { "Pastry", 0 }, { "Fruit Pie", 0 } };
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currLiquid = liquids.Peek();
                int cuurIngredient = ingredients.Peek();

                if (currLiquid + cuurIngredient == 25)
                {
                    foods["Bread"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (currLiquid + cuurIngredient == 50)
                {
                    foods["Cake"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (currLiquid + cuurIngredient == 75)
                {
                    foods["Pastry"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (currLiquid + cuurIngredient == 100)
                {
                    foods["Fruit Pie"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    cuurIngredient += 3;
                    ingredients.Pop();
                    ingredients.Push(cuurIngredient);
                }
            }

            if (foods.ContainsValue(0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var food in foods.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
