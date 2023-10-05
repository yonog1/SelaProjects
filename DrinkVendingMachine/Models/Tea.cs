using System.Collections.Generic;
using System.Text;

namespace DrinkVendingMachine.Models
{
    internal class Tea : Beverage
    {
        public Tea() : base("Tea", 1.90, new List<string> { "Water", "Leaves", "Sugar" })
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
            sb.Append($"and {Ingredients[Ingredients.Count - 1]} to make ${Name}...");

            return sb.ToString();
        }

        public override string AddHotWater()
        {
            return $"Adding hot water at 75 degrees to make tea...";
        }

        public override string Stir()
        {
            return $"Stirring the tea for 15 seconds...";
        }
    }
}
