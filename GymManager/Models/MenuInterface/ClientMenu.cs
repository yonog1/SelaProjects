using GymManager.Models.Validation;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace GymManager.Models.MenuInterface
{
    internal class ClientMenu
    {
        public static void Menu()
        {
            string input = "";  // Initialize input variable here

            while (input != "0")
            {
                Console.Clear();
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
            Console.Clear();
            string clientsFolderPath = "Clients";
            if (!Directory.Exists(clientsFolderPath))
            {
                Console.WriteLine("No clients found.");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("List of existing clients:");
            string[] clientDirectories = Directory.GetDirectories(clientsFolderPath);

            foreach (string clientDirectory in clientDirectories)
            {
                string clientId = Path.GetFileName(clientDirectory);
                Console.WriteLine(clientId);
            }
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();
        }

        private static void DeleteClient()
        {
            Console.Clear();
            Console.WriteLine("Enter the client ID you want to delete:");
            string clientId = ValidationClass.ValidateId();
            string clientDirectoryPath = Path.Combine("Clients", clientId);
            string clientFilePath = Path.Combine(clientDirectoryPath, "client.json");
            Console.WriteLine(clientId);

            //string clientFilePath = $"Clients/{clientId}";

            if (!File.Exists(clientFilePath))
            {
                Console.WriteLine("Client not found.");
                return;
            }
            string json = File.ReadAllText(clientFilePath);
            JObject jsonClient = JObject.Parse(json);

            // Set IsActive property to false
            jsonClient["IsActive"] = false;

            // Write the updated JSON back to the file
            File.WriteAllText(clientFilePath, jsonClient.ToString());

            Console.WriteLine("Client deleted successfully.");

        }

        private static void EditClient()
        {
            Console.Clear();
            Console.WriteLine("Enter the client ID you want to edit:");
            string clientId = Console.ReadLine();
            string clientDirectory = Path.Combine("Clients/", clientId);
            string clientFilePath = Path.Combine(clientDirectory, "client.json");

            if (!File.Exists(clientFilePath))
            {
                Console.WriteLine("Client not found.");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            string text = File.ReadAllText(clientFilePath);
            JObject jsonClient = JObject.Parse(text);

            Console.WriteLine("Current client details:");
            foreach (var item in jsonClient)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine("\nEnter the property to change:\n(type \"Cancel\" to cancel operation)");
            string inputProperty = Console.ReadLine();

            // Convert inputProperty to lowercase for case-insensitive comparison
            inputProperty = inputProperty.ToLower();

            if (inputProperty == "cancel")
            {
                Console.WriteLine("Operation cancelled\n");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            // Find the property with case-insensitive comparison
            string propertyName = jsonClient.Properties()
                .FirstOrDefault(prop => prop.Name.Equals(inputProperty, StringComparison.OrdinalIgnoreCase))?.Name;

            if (propertyName != null)
            {
                // Validate and set the new value
                switch (propertyName)
                {
                    case "Id":
                        string newValue = ValidationClass.ValidateId();
                        jsonClient[propertyName] = newValue;
                        break;
                    case "FirstName":
                        newValue = ValidationClass.ValidateName("Please enter First name (only letters):");
                        jsonClient[propertyName] = newValue;
                        break;
                    case "LastName":
                        newValue = ValidationClass.ValidateName("Please enter Last name (only letters):");
                        jsonClient[propertyName] = newValue;
                        break;
                    case "Gender":
                        char genderValue = ValidationClass.ValidateGender();
                        jsonClient[propertyName] = genderValue.ToString(); ;
                        break;
                    case "BirthDate":
                        newValue = ValidationClass.ValidateBirthDate();
                        jsonClient[propertyName] = newValue;
                        break;
                    case "City":
                        newValue = ValidationClass.ValidateCity();
                        jsonClient[propertyName] = newValue;
                        break;
                    case "Address":
                        newValue = ValidationClass.ValidateAddress();
                        jsonClient[propertyName] = newValue;
                        break;
                    case "PhoneNumber":
                        newValue = ValidationClass.ValidatePhoneNumber();
                        jsonClient[propertyName] = newValue;
                        break;
                    case "Email":
                        newValue = ValidationClass.ValidateEmail();
                        jsonClient[propertyName] = newValue;
                        break;
                    case "Height":
                        double heightValue = ValidationClass.ValidateHeight();
                        jsonClient[propertyName] = heightValue;
                        break;
                    case "Weight":
                        double weightValue = ValidationClass.ValidateWeight();
                        jsonClient[propertyName] = weightValue;
                        break;
                    default:
                        Console.WriteLine($"Property {propertyName} is not editable.");
                        break;
                }

                // Serialize the updated JSON and write back to the file
                string updatedJson = jsonClient.ToString();
                File.WriteAllText(clientFilePath, updatedJson);

                Console.WriteLine("Client details updated successfully.");
            }
            else
            {
                Console.WriteLine($"Property {inputProperty} not found.");
            }

            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();
        }


        private static void AddClient()
        {
            // Call validators to set values for new client
            Console.Clear();
            Client client = new Client
            {
                Id = ValidationClass.ValidateId(),
                FirstName = ValidationClass.ValidateName("Please enter First name (only letters):"),
                LastName = ValidationClass.ValidateName("Please enter Lastname (only letters):"),

                Gender = ValidationClass.ValidateGender(),
                BirthDate = ValidationClass.ValidateBirthDate(),
                City = ValidationClass.ValidateCity(),
                Address = ValidationClass.ValidateAddress(),
                PhoneNumber = ValidationClass.ValidatePhoneNumber(),
                Email = ValidationClass.ValidateEmail(),

                Height = ValidationClass.ValidateHeight(),
                Weight = ValidationClass.ValidateWeight(),
            };

            Console.WriteLine("\nbmi is: " + client.CalculateBMI());

            FileHandler.CreateClientFile(client);

            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();


            //Create json file with serialized object data
        }
    }
}
