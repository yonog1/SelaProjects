using System;

namespace GymManager.Models
{
    internal class Client : Person
    {
        private double height;

        public double Height
        {
            get { return height; }
            set
            {
                double input;
                do
                {
                    Console.WriteLine("Please enter height:");
                    input = double.TryParse(Console.ReadLine(), out input) ? input : -1;

                } while (input < 0);
                value = input;
                height = value;
            }
        }

        private double weight;

        public double Weight
        {
            get { return weight; }
            set
            {
                double input;
                do
                {
                    Console.WriteLine("Please enter weight:");
                    input = double.TryParse(Console.ReadLine(), out input) ? input : -1;

                } while (input < 0);
                value = input;
                weight = value;
            }
        }

        public double CalculateBMI()
        {
            return weight * Math.Pow(height, 2);
        }

    }
}
