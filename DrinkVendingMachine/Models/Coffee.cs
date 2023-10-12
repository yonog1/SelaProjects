using System.Collections.Generic;

namespace DrinkVendingMachine.Models
{
    internal class Coffee : Beverage
    {
        public Coffee() : base("Coffee", 2.50, new List<string> { "Coffee Beans", "Water" })
        {
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
