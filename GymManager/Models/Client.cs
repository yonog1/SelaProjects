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
                height = value;
            }
        }

        private double weight;

        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
            }
        }

        public double CalculateBMI()
        {
            return weight * Math.Pow(height, 2);
        }

    }
}
