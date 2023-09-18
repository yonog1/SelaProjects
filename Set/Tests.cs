using System;

namespace Set
{
    public class Tests
    {
        static Random rnd = new Random();

        public static void DeleteTest()
        {
            // delete test
            Console.WriteLine("delete test");
            Set set1 = new Set();
            PopulateSet(set1);
            Console.WriteLine(set1);
            int input;
            do
            {
                Console.WriteLine("enter a number (0-1000) :");
                input = int.TryParse(Console.ReadLine(), out input) ? input : -1;
            } while (!(0 < input && input < 1001));
            set1.Delete(input);
            Console.WriteLine($"Set 8 - {set1}");
        }

        public static void InsertTest()
        {
            // insert test
            Console.WriteLine("insert test");
            Set set1 = new Set();
            PopulateSet(set1);
            Console.WriteLine(set1);
            int input;
            do
            {
                Console.WriteLine("enter a number (0-1000) :");
                input = int.TryParse(Console.ReadLine(), out input) ? input : -1;
            } while (!(0 < input && input < 1001));
            set1.Insert(input);
            Console.WriteLine($"Set 7 - {set1}");
        }

        public static void IsMemberTest()
        {
            // is member test
            Console.WriteLine("is member test");
            Set set1 = new Set();
            PopulateSet(set1);
            Console.WriteLine($"Set 6 - {set1}");
            Console.WriteLine("enter num (0-1000): ");
            int input = int.TryParse(Console.ReadLine(), out input) ? input : -1;
            Console.WriteLine(set1.IsMember(input));
        }

        public static void SubsetTest()
        {
            // Subset test
            Console.WriteLine("subset test");
            Set set1 = new Set();
            PopulateSet(set1);
            Console.WriteLine($"Set 5 - {set1}");

            // ask user for input and store it in array
            int[] userInput = new int[3];
            Console.WriteLine("Enter 3 numbers (0-1000): ");
            for (int i = 0; i < userInput.Length; i++)
            {
                do
                {
                    Console.WriteLine($"Num {i + 1}: ");
                    string stringInput = Console.ReadLine();
                    userInput[i] = int.TryParse(stringInput, out userInput[i]) ? userInput[i] : -1;
                }
                while (userInput[i] < 0);
            }

            Set userInputSet = new Set(userInput);
            Console.WriteLine($"User's set - {userInputSet}");
            Console.WriteLine(set1.Subset(userInputSet));
        }

        public static void IntersectionTest()
        {
            // Intersection test
            Console.WriteLine("intersection test");
            Set set1 = new Set();
            PopulateSet(set1);
            Console.Write("Set 3 - ");
            Console.WriteLine(set1);

            Set set2 = new Set();
            PopulateSet(set2);
            Console.Write("Set 4 - ");
            Console.WriteLine(set2);

            set1.Intersection(set2);
            Console.WriteLine("Intersection of Set 3 and Set 4: ");
            Console.WriteLine(set1);
        }

        public static void UnionTest()
        {
            // Union test
            Console.WriteLine("union test");
            Set set1 = new Set();
            PopulateSet(set1);
            Console.Write("Set 1 - ");
            Console.WriteLine(set1);

            Set set2 = new Set();
            PopulateSet(set2);
            Console.Write("Set 2 - ");
            Console.WriteLine(set2);

            set1.Union(set2);
            Console.WriteLine("Union of Set 1 and Set 2: ");
            Console.WriteLine(set1);
        }

        private static void PopulateSet(Set set)
        {
            //Random rnd = new Random();
            for (int i = 0; i < 12; i++)
            {
                set.Insert(rnd.Next(1001));
            }
        }
    }
}
