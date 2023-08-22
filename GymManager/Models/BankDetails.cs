using System;
using System.Linq;

namespace GymManager.Models
{
    internal class BankDetails
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                string input;
                do
                {
                    Console.WriteLine("Enter your bank's name:");
                    input = Console.ReadLine();
                }
                while (input.All(char.IsLetter) == false);
                value = input;
                name = value;
            }
        }

        private int branch;
        public int Branch
        {
            get { return branch; }
            set
            {
                int input;
                do
                {
                    Console.WriteLine("Enter your account's branch:");
                    input = int.TryParse(Console.ReadLine(), out input) ? input : -1;
                }
                while (input > 1000 || input < 0);
                value = input;
                branch = value;
            }
        }

        private int accountNumber;
        public int AccountNumber
        {
            get { return accountNumber; }
            set
            {
                int input;
                do
                {
                    Console.WriteLine("Enter your bank account number:");
                    input = int.TryParse(Console.ReadLine(), out input) ? input : -1;
                }
                while (input > 1000000 || input < 0);
                value = input;
                accountNumber = value;
            }
        }



    }
}
