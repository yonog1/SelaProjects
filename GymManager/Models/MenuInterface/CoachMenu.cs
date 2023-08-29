using GymManager.Models.Validation;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace GymManager.Models.MenuInterface
{
    internal class CoachMenu
    {
        public static void Menu()
        {
            string input = "";  // Initialize input variable here

            while (input != "0")
            {
                Console.Clear();
                Console.WriteLine("Coaches menu:");
                Console.WriteLine("1 - Add Coach");
                Console.WriteLine("2 - Edit Coach");
                Console.WriteLine("3 - Delete Coach");
                Console.WriteLine("4 - View Coach List");
                Console.WriteLine("0 - Back to Main Menu");

                input = Console.ReadLine();  // Read user input here

                switch (input)
                {
                    case "1":
                        AddCoach();
                        break;
                    case "2":
                        EditCoach();
                        break;
                    case "3":
                        DeleteCoach();
                        break;
                    case "4":
                        ViewCoachList();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                        break;
                }
            }
        }

        private static void ViewCoachList()
        {
            Console.Clear();
            string CoachesFolderPath = "Coaches/";
            if (!Directory.Exists(CoachesFolderPath))
            {
                Console.WriteLine("No Coaches found.");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine("List of existing Coaches:");
            string[] CoachDirectories = Directory.GetDirectories(CoachesFolderPath);

            foreach (string CoachDirectory in CoachDirectories)
            {
                string CoachId = Path.GetFileName(CoachDirectory);
                Console.WriteLine(CoachId);
            }
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();
        }

        private static void DeleteCoach()
        {
            Console.Clear();
            Console.WriteLine("Enter the Coach ID you want to delete:");
            string CoachId = ValidationClass.ValidateId();
            string CoachDirectoryPath = Path.Combine("Coaches/", CoachId);
            string CoachFilePath = Path.Combine(CoachDirectoryPath, "Coach.json");
            Console.WriteLine(CoachId);

            //string CoachFilePath = $"Coaches/{CoachId}";

            if (!File.Exists(CoachFilePath))
            {
                Console.WriteLine("Coach not found.");
                return;
            }
            // Read file contets as text
            string json = File.ReadAllText(CoachFilePath);
            // Format the contents to json
            JObject jsonCoach = JObject.Parse(json);

            // Set IsActive property to false
            jsonCoach["IsActive"] = false;

            // Write the updated JSON back to the file
            File.WriteAllText(CoachFilePath, jsonCoach.ToString());

            Console.WriteLine("Coach deleted successfully.");

        }

        private static void EditCoach()
        {
            Console.Clear();
            Console.WriteLine("Enter the Coach ID you want to edit:");
            string CoachId = Console.ReadLine();
            string CoachDirectory = Path.Combine("Coaches", CoachId);
            string CoachFilePath = Path.Combine(CoachDirectory, "Coach.json");

            if (!File.Exists(CoachFilePath))
            {
                Console.WriteLine("Coach not found.");
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            string text = File.ReadAllText(CoachFilePath);
            JObject jsonCoach = JObject.Parse(text);

            Console.WriteLine("Current Coach details:");
            foreach (var item in jsonCoach)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("Enter the property to change:\n(type \"Cancel\" to cancel operation)");
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
            string propertyName = jsonCoach.Properties()
                .FirstOrDefault(prop => prop.Name.Equals(inputProperty, StringComparison.OrdinalIgnoreCase))?.Name;

            if (propertyName != null)
            {
                // Validate and set the new value, calling the appropriate validation function.
                switch (propertyName)
                {
                    case "Id":
                        string newValue = ValidationClass.ValidateId();
                        jsonCoach[propertyName] = newValue;
                        break;
                    case "FirstName":
                        newValue = ValidationClass.ValidateName("Please enter First name (only letters):");
                        jsonCoach[propertyName] = newValue;
                        break;
                    case "LastName":
                        newValue = ValidationClass.ValidateName("Please enter Last name (only letters):");
                        jsonCoach[propertyName] = newValue;
                        break;
                    case "Gender":
                        char genderValue = ValidationClass.ValidateGender();
                        jsonCoach[propertyName] = genderValue.ToString(); ;
                        break;
                    case "BirthDate":
                        newValue = ValidationClass.ValidateBirthDate();
                        jsonCoach[propertyName] = newValue;
                        break;
                    case "City":
                        newValue = ValidationClass.ValidateCity();
                        jsonCoach[propertyName] = newValue;
                        break;
                    case "Address":
                        newValue = ValidationClass.ValidateAddress();
                        jsonCoach[propertyName] = newValue;
                        break;
                    case "PhoneNumber":
                        newValue = ValidationClass.ValidatePhoneNumber();
                        jsonCoach[propertyName] = newValue;
                        break;
                    case "Email":
                        newValue = ValidationClass.ValidateEmail();
                        jsonCoach[propertyName] = newValue;
                        break;
                    case "Height":
                        double heightValue = ValidationClass.ValidateHeight();
                        jsonCoach[propertyName] = heightValue;
                        break;
                    case "Weight":
                        double weightValue = ValidationClass.ValidateWeight();
                        jsonCoach[propertyName] = weightValue;
                        break;
                    default:
                        Console.WriteLine($"Property {propertyName} is not editable.");
                        break;
                }

                // Serialize the updated JSON and write back to the file
                string updatedJson = jsonCoach.ToString();
                File.WriteAllText(CoachFilePath, updatedJson);

                Console.WriteLine("Coach details updated successfully.");
            }
            else
            {
                Console.WriteLine($"Property {inputProperty} not found.");
            }

            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();
        }


        private static void AddCoach()
        {
            // Call validators to set values for new coach
            Console.Clear();
            Coach coach = new Coach
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

                Profession = ValidationClass.ValidatePorfession(),
                bankDetails = new BankDetails(),
            };

            coach.bankDetails.Name = ValidationClass.ValidateName("Enter your bank's name:");

            coach.bankDetails.Branch = ValidationClass.ValidateBankBranch();

            coach.bankDetails.AccountNumber = ValidationClass.ValidateBankAccountNumber();

            FileHandler.CreateCoachFile(coach);

            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();


            //Create json file with serialized object data
        }
    }
}
