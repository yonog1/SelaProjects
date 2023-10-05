using System.Collections.Generic;
using System.Text;

namespace DrinkVendingMachine
{
    internal abstract class Beverage
    {
        public Beverage(string name, double price, List<string> ingredients)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
            Id = id;
            id++;
        }

        private static int id = 0;

        public int Id { get; }
        public string Name { get; }
        public double Price { get; }
        protected List<string> Ingredients { get; }

        public string Prepare()
        {
            StringBuilder sb = new StringBuilder();
            AddIngredients();
            return sb.ToString();
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
