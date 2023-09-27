using System.Collections.Generic;

namespace DrinkVendingMachine
{
    internal abstract class Drink
    {
        public Drink(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }

        public void Prepare()
        {

        }

        public abstract string AddIngredients(List<string> ingredients);

        public abstract string AddHotWater(int temperature);

        public abstract string Stir(int seconds);

    }
}
