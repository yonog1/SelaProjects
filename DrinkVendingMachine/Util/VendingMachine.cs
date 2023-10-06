using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrinkVendingMachine
{
    internal class VendingMachine
    {
        private List<Beverage> beveragesList = new List<Beverage>();
        public int Count { get; private set; }

        private const int LIMIT = 16;

        public VendingMachine()
        {
            Count++;
        }

        public Beverage this[string name]
        {
            get
            {
                foreach (var beverage in beveragesList)
                {
                    if (beverage.Name == name)
                    {
                        return beverage;
                    }
                }
                return null;
            }
        }

        public Beverage this[int id]
        {
            get
            {
                foreach (var beverage in beveragesList)
                {
                    if (beverage.Id == id)
                    {
                        return beverage;
                    }
                }
                return null;
            }
        }

        public string ListBeverages()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Beverage item in beveragesList)
            {
                sb.Append($"{item.Id} : {item.Name}\n");
            }
            return sb.ToString();
        }

        public string Prepare(int id)
        {
            Beverage selectedBeverage = beveragesList.FirstOrDefault(beverage => beverage.Id == id);
            if (selectedBeverage == null)
                throw new InvalidOperationException($"Beverage with ID {id} was not found in the list.");

            return selectedBeverage.Prepare();
        }

        public void AddBeverage(Beverage beverage)
        {
            if (Count > LIMIT)
                throw new OverflowException($"Cant add ${beverage.Name} because the machine's maximum capacity is reached.\nPlease remove an item before trying to add another one.");
            beveragesList.Add(beverage);
        }

        public void RemoveBeverage(Beverage beverage)
        {
            beveragesList.Remove(beverage);
        }
    }

}
