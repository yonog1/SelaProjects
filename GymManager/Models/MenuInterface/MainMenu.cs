using System;

namespace GymManager.Models.MenuInterface
{
    internal class MainMenu
    {
        public static void Menu()
        {
            string input = "";
            while (input != "0")
            {
                Console.Clear();
                Console.WriteLine("Welcome to Jim's Gym! What do you want to do today?\n");
                Console.WriteLine("Press 1 to go to the Client's menu.\n" +
                    "Press 2 to go to the Coach's menu.\n" +
                    "Press 0 to quit."
                    );
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ClientMenu.Menu();
                        break;

                    case "2":
                        CoachMenu.Menu();
                        break;
                }
            }
        }
    }
}
