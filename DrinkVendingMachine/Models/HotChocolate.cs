using System.Collections.Generic;

namespace DrinkVendingMachine.Models
{
    internal class HotChocolate : Beverage
    {
        public HotChocolate() : base("Hot Chocolate", 7.50, new List<string> { "Cocoa", "Sugar", "Milk", "Water" })
        {
        }

        public override string AddHotWater()
        {
            return $"Adding hot water at 70 degrees to make hot chocolate...";
        }

        public override string Stir()
        {
            return $"Stirring the hot chocolate for 20 seconds...";
        }
    }
}
