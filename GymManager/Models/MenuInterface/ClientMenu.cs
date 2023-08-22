using System;

namespace GymManager.Models.MenuInterface
{
    internal class ClientMenu
    {
        public static void Menu()
        {

            Console.WriteLine("Clients menu:");
            string input = "";
            while (true)
            {
                switch (input)
                {
                    case "1":
                        AddClient();
                        break;
                    case "2":
                        AddClient();
                        break;
                    case "3":
                        AddClient();
                        break;
                    case "4":
                        AddClient();
                        break;
                    case "0":
                        MainMenu.Menu();
                        break;

                }
                Console.ReadLine();
            }

        }

        private static void AddClient()
        {
            Client client = new Client();
            client.FirstName = Console.ReadLine();
            client.LastName = Console.ReadLine();
            client.Gender = char.Parse(Console.ReadLine());
            client.BirthDate = Console.ReadLine();
            client.City = Console.ReadLine();
            client.Address = Console.ReadLine();
            client.PhoneNumber = Console.ReadLine();
            client.Email = Console.ReadLine();
            client.Height = double.Parse(Console.ReadLine());
            client.Weight = double.Parse(Console.ReadLine());
            Console.WriteLine("bmi is: " + client.CalculateBMI());

            //Create json file with serialized object data
        }

        private static void Edit(int clientId)
        {
            //Load object's json file and change property value by key (user input)
        }
    }
}
