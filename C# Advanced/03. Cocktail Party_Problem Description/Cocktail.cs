using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> Ingredients;

        public Cocktail(string name, int capacity, int maxAlcohol)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcohol;
            Ingredients = new List<Ingredient>(Capacity);
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol); 
        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Any(x => x.Name == ingredient.Name) && Ingredients.Count < Capacity && ingredient.Alcohol <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name) => Ingredients.Remove(Ingredients.Find(x => x.Name == name));
            
        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.Any(x => x.Name == name))
            {
                return (Ingredient)Ingredients.Find(x => x.Name == name);
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient() => Ingredients.OrderByDescending(x => x.Alcohol).First();

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            sb.AppendLine(string.Join(Environment.NewLine, Ingredients));

            return sb.ToString().TrimEnd();
        }

    }
}
