using System;
using System.Collections.Generic;

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

        public abstract string AddIngredients();

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
