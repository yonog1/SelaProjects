using DrinkVendingMachine.Models;
using System;

namespace DrinkVendingMachine.Util
{
    internal class Menu
    {
        public static void MainMenu()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Coffee coffee = new Coffee();
            Tea tea = new Tea();
            vendingMachine.AddBeverage(coffee);
            vendingMachine.AddBeverage(tea);


            string input = "";
            while (input != "0")
            {


                Console.WriteLine("Main Menu");
                Console.WriteLine("---------");
                Console.WriteLine("Enter a number to prepare a beverage from the list:\n");
                Console.WriteLine(vendingMachine.ListBeverages());

                input = Console.ReadLine();
            }
        }
    }
}
