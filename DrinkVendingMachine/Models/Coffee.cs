using System.Collections.Generic;
using System.Text;

namespace DrinkVendingMachine.Models
{
    internal class Coffee : Beverage
    {
        public Coffee() : base("Coffee", 2.50, new List<string> { "Coffee Beans", "Water" })
        {
        }


        public override string AddIngredients()
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

        public override string AddHotWater()
        {
            return $"Adding hot water at 60 degrees to make coffee...";
        }

        public override string Stir()
        {
            return $"Stirring the coffee for 5 seconds...";
        }
    }
}
