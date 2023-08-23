using GymManager.Models.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GymManager.Models.MenuInterface
{
    internal class ClientMenu
    {
        public static void Menu()
        {
            string input = "";  // Initialize input variable here

            while (input != "0")
            {
                Console.WriteLine("Clients menu:");
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
                        EditClient();
                        break;
                    case "3":
                        DeleteClient();
                        break;
                    case "4":
                        ViewClientList();
                        break;
                    case "0":
                        return;
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

        private static void EditClient() // WIP! NOT READY
        {
            Console.Clear();
            Console.WriteLine("Enter the client ID you want to edit:");
            string clientId = Console.ReadLine();
            string clientDirectory = Path.Combine("Clients", clientId);
            string clientFilePath = Path.Combine(clientDirectory, "client.json");

            if (!File.Exists(clientFilePath))
            {
                Console.WriteLine("Client not found.");
                return;
            }

            string json = File.ReadAllText(clientFilePath);
            Dictionary<string, object> client = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            Console.WriteLine("Current client details:");
            foreach (var item in client)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("enter property to change");
            string input = Console.ReadLine();

            if (client.ContainsKey(input))
            {
                client[input] = Console.ReadLine();
            }

            // Serialize the updated client object and write back to the JSON file
            string updatedJson = JsonConvert.SerializeObject(client, Formatting.Indented);
            File.WriteAllText(clientFilePath, updatedJson);

            Console.WriteLine("Client details updated successfully.");
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }





        private static void AddClient()
        {
            Client client = new Client();
            client.Id = ValidationClass.ValidateId();
            client.FirstName = ValidationClass.ValidateName("Please enter First name (only letters):");
            client.LastName = ValidationClass.ValidateName("Please enter Lastname (only letters):");

            client.Gender = ValidationClass.ValidateGender(); ;

            client.BirthDate = ValidationClass.ValidateBirthDate(); ;
            client.City = ValidationClass.ValidateCity(); ;
            client.Address = ValidationClass.ValidateAddress();
            client.PhoneNumber = ValidationClass.ValidatePhoneNumber(); ;
            client.Email = ValidationClass.ValidateEmail();

            client.Height = ValidationClass.ValidateHeight(); ;
            client.Weight = ValidationClass.ValidateWeight(); ;
            Console.WriteLine("bmi is: " + client.CalculateBMI());

            FileHandler.CreateClientFile(client);

            //Create json file with serialized object data
        }
    }
}
