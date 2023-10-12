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
            HotChocolate hotChocolate = new HotChocolate();
            vendingMachine.AddBeverage(coffee);
            vendingMachine.AddBeverage(tea);
            vendingMachine.AddBeverage(hotChocolate);


            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("---------");
                Console.WriteLine(vendingMachine.ListBeverages());

                Console.WriteLine("Enter a number to prepare a beverage from the list:\nEnter '0' to exit\n");

                string input = Console.ReadLine();

                if (input == "0")
                    break;

                int intInput = int.TryParse(input, out intInput) ? intInput : -1;

                try
                {
                    Console.Clear();
                    Console.WriteLine(vendingMachine.Prepare(intInput));
                    Console.WriteLine("Your beverage is ready!\nPress any key to continue...\n");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue...\n");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }
    }
}
