using System;

namespace GymManager.Models
{
    internal class Coach : Person
    {
        public BankDetails bankDetails { get; set; }

        private string profession;

        public string Profession
        {
            get { return profession; }
            set
            {
                string input;
                do
                {
                    Console.WriteLine("Please enter profession:");
                    input = Console.ReadLine();
                } while (input.Length < 4);
                value = input;
                profession = value;
            }
        }


    }
}
