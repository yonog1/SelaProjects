using System;
using System.Linq;

namespace GymManager.Models.Validation
{
    internal class ValidationClass
    {
        public static string ValidateId()
        {
            string input;
            do
            {
                Console.WriteLine("Please enter Id number (9 digits):");
                input = Console.ReadLine();
            } while (!(int.TryParse(input, out _) && input.Length == 9));
            return input;
        }

        public static string ValidateName(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
            } while (!input.All(char.IsLetter) || input.Length < 1);
            return input;
        }

        public static char ValidateGender()
        {
            char input;
            char[] options = { 'o', 'O', 'm', 'M', 'f', 'F' };
            do
            {
                Console.WriteLine("Please enter gender(F / M / O).");
            } while (!char.TryParse(Console.ReadLine(), out input) || !options.Contains(input));

            return input;
        }

        // Implement the remaining validation methods similarly
        // ValidateBirthDate(), ValidateCity(), ValidateAddress(), ValidatePhoneNumber(), ValidateEmail()

        public static string ValidateBirthDate()
        {
            string input;
            int y, m, d;

            do
            {
                Console.WriteLine("Please enter birth year:");
            } while (!int.TryParse(Console.ReadLine(), out y) || y < 1900 || y > DateTime.Now.Year);

            do
            {
                Console.WriteLine("Please enter birth month:");
            } while (!int.TryParse(Console.ReadLine(), out m) || m < 1 || m > 12);

            do
            {
                Console.WriteLine("Please enter birth day:");
            } while (!int.TryParse(Console.ReadLine(), out d) || d < 1 || d > DateTime.DaysInMonth(y, m));

            input = $"{d:D2}/{m:D2}/{y:D4}";
            return input;
        }

        public static string ValidateCity()
        {
            string input;
            do
            {
                Console.WriteLine("Please enter city:");
                input = Console.ReadLine();
            } while (!input.All(char.IsLetter));
            return input;
        }

        public static string ValidateAddress()
        {
            string input;
            do
            {
                Console.WriteLine("Please enter address:");
                input = Console.ReadLine();
            } while (input.Length < 1);
            return input;
        }

        public static string ValidatePhoneNumber()
        {
            string input;
            do
            {
                Console.WriteLine("Please enter phone number:");
                input = Console.ReadLine();
            } while (!input.All(char.IsDigit) || input[0] != '0');
            return input;
        }

        public static string ValidateEmail()
        {
            string input;
            do
            {
                Console.WriteLine("Please enter email address (use '@'):");
                input = Console.ReadLine();
            } while (!input.Contains('@'));
            return input;
        }

        public static double ValidateHeight()
        {
            double input;
            do
            {
                Console.WriteLine("Please enter height:");
            } while (!double.TryParse(Console.ReadLine(), out input) || input < 0);
            return input;
        }

        public static double ValidateWeight()
        {
            double input;
            do
            {
                Console.WriteLine("Please enter weight:");
            } while (!double.TryParse(Console.ReadLine(), out input) || input < 0);
            return input;
        }

        public static int ValidateBankBranch()
        {
            int input;
            do
            {
                Console.WriteLine("Enter your account's branch:");
                input = int.TryParse(Console.ReadLine(), out input) ? input : -1;
            }
            while (input > 1000 || input < 0);

            return input;
        }

        public static int ValidateBankAccountNumber()
        {
            int input;
            do
            {
                Console.WriteLine("Enter your account's number:");
                input = int.TryParse(Console.ReadLine(), out input) ? input : -1;
            }
            while (input > 1000000 || input < 0);

            return input;
        }

        public static string ValidatePorfession()
        {
            string input;
            do
            {
                Console.WriteLine("Please enter profession:");
                input = Console.ReadLine();
            } while (input.Length < 4);

            return input;
        }
    }
}
