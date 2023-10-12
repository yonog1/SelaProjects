using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkVendingMachine
{
    internal abstract class Beverage
    {
        public Beverage(string name, double price, List<string> ingredients)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty or null.", nameof(name));

            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.", nameof(price));

            if (ingredients == null || ingredients.Count == 0)
                throw new ArgumentException("Ingredients list must have at least one element.", nameof(ingredients));

            Name = name;
            Price = price;
            Ingredients = ingredients;
            Id = id;
            id++;
        }

        private static int id = 1;

        public int Id { get; }
        public string Name { get; }
        public double Price { get; }
        protected List<string> Ingredients { get; }

        public string Prepare()
        {
            return $"{AddIngredients()}\n{AddHotWater()}\n{Stir()}";
        }

        public string AddIngredients()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Adding ");
            for (int i = 0; i < Ingredients.Count - 1; i++)
            {
                sb.Append($"{Ingredients[i]}, ");
            }
            sb.Remove(sb.Length - 2, 1);
            sb.Append($"and {Ingredients[Ingredients.Count - 1]} to make {Name}...");

            return sb.ToString();
        }

        public abstract string AddHotWater();

        public abstract string Stir();

        public override bool Equals(object obj)
        {
            if (obj is Beverage)
                return this.Name == ((Beverage)obj).Name;
            return false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
