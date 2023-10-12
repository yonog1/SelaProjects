using System.Collections.Generic;

namespace DrinkVendingMachine.Models
{
    internal class Tea : Beverage
    {
        public Tea() : base("Tea", 1.90, new List<string> { "Water", "Leaves", "Sugar" })
        {
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
