using System;

namespace GymManager.Models.MenuInterface
{
    internal class ClientMenu
    {
        public static void Menu()
        {
            string input = "";  // Initialize input variable here

            Console.WriteLine("Clients menu:");
            while (input != "0")
            {
                Console.WriteLine("1 - Add Client");
                Console.WriteLine("2 - Edit Client");
                Console.WriteLine("3 - Delete Client");
                Console.WriteLine("4 - View Client List");
                Console.WriteLine("0 - Back to Main Menu");

                input = Console.ReadLine();  // Read user input here

                switch (input)
                {
                    case "1":
                        AddClient();
                        break;
                    case "2":
                        EditClient(1);
                        break;
                    case "3":
                        DeleteClient();
                        break;
                    case "4":
                        ViewClientList();
                        break;
                    case "0":
                        MainMenu.Menu();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                        break;
                }
            }
        }

        private static void ViewClientList()
        {
            throw new NotImplementedException();
        }

        private static void DeleteClient()
        {
            throw new NotImplementedException();
        }

        private static void EditClient(int clientId)
        {
            //Load object's json file and change property value by key (user input)
            throw new NotImplementedException();
        }

        private static void AddClient()
        {
            Client client = new Client();
            client.FirstName = Console.ReadLine();
            client.LastName = Console.ReadLine();

            char genderInput = (char)Console.Read();
            client.Gender = genderInput;

            client.BirthDate = Console.ReadLine();
            client.City = Console.ReadLine();
            client.Address = Console.ReadLine();
            client.PhoneNumber = Console.ReadLine();
            client.Email = Console.ReadLine();
            double h;
            double.TryParse(Console.ReadLine(), out h);
            client.Height = h;
            double w;
            double.TryParse(Console.ReadLine(), out w);
            client.Weight = w;
            Console.WriteLine("bmi is: " + client.CalculateBMI());

            //Create json file with serialized object data
        }
    }
}
