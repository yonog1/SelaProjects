using System;
using System.Linq;

namespace GymManager.Models
{
    internal class Person
    {
        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                string input;
                do
                {
                    Console.WriteLine("Please enter Id number (9 digits):");
                    input = Console.ReadLine();
                }
                while (!(int.TryParse(input, out _) && input.Length == 9));
                value = input;
                id = value;
            }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                string input;
                do
                {
                    Console.WriteLine("Please enter First name (only letters):");
                    input = Console.ReadLine();
                } while (input.All(Char.IsLetter) == false || input.Length < 1);
                value = input;
                firstName = value;
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                string input;
                do
                {
                    Console.WriteLine("Please enter Last name (only letters):");
                    input = Console.ReadLine();
                }
                while (input.All(Char.IsLetter) == false || input.Length < 1);
                value = input;
                lastName = value;
            }
        }

        private char gender;

        public char Gender
        {
            get { return gender; }
            set
            {
                char input;
                char[] options = { 'o', 'O', 'm', 'M', 'f', 'F' };
                do
                {
                    Console.WriteLine("Please enter gender(F / M / O).");
                    char.TryParse(Console.ReadLine(), out input);
                }
                while (!options.Contains(input));
                value = input;
                gender = value;
            }
        }

        private string birthDate;

        public string BirthDate
        {
            get { return birthDate; }
            set
            {
                string year;
                int y;
                string month;
                int m;
                string day;
                int d;
                do
                {
                    Console.WriteLine("Please enter birth year:");
                    year = Console.ReadLine();
                    int.TryParse(year, out y);
                }
                while (!year.All(Char.IsDigit) || y > 2023);

                do
                {
                    Console.WriteLine("Please enter birth month:");
                    month = Console.ReadLine();
                    int.TryParse(month, out m);
                }
                while (!month.All(Char.IsDigit) || m < 1 || m > 12);

                do
                {
                    Console.WriteLine("Please enter birth day:");
                    day = Console.ReadLine();
                    int.TryParse(day, out d);
                }
                while (!day.All(Char.IsDigit) || d < 1 || d > 31);
                value = $"{d:D2}/{m:D2}/{y:D4}";
                birthDate = value;
            }
        }

        private string city;

        public string City
        {
            get { return city; }
            set
            {
                string input;
                do
                {
                    Console.WriteLine("Please enter city:");
                    input = Console.ReadLine();
                }
                while (input.All(char.IsLetter) == false);
                value = input;
                city = value;
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                string input;
                do
                {
                    Console.WriteLine("Please enter address:");
                    input = Console.ReadLine();
                }
                while (input.Length < 0);
                value = input;
                address = value;
            }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                string input;
                do
                {
                    Console.WriteLine("Please enter phone number:");
                    input = Console.ReadLine();
                }
                while (input.All(char.IsDigit) != false && input[0] == '0');
                value = input;
                phoneNumber = value;
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                string input;
                do
                {
                    Console.WriteLine("Please enter email address (use '@'):");
                    input = Console.ReadLine();
                }
                while (input.Contains('@') == false);
                value = input;
                email = value;
            }
        }


    }
}
