using BoardLogic;

namespace TicTacToeCore
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Board game = new();

            while (game.numOfTurns < 9) // cant be more than 9 turns, board is 3x3
            {
                Console.Clear();
                PrintBoard(game.Grid);

                int row;
                int column;

                while (true) // Get user input from console until its valid
                {
                    row = GetBoundedIntInput(1, 3, "Enter the row number [1-3]:") - 1;
                    column = GetBoundedIntInput(1, 3, "Enter the column number [1-3]:") - 1;

                    if (game.IsPlaceAvailable(row, column))
                    {
                        break; // if input is valid the game loop will continue
                    }
                    else
                    {
                        Console.WriteLine($"This position ({row + 1},{column + 1}) is already taken, please choose another one.\nPress any key to continue:");
                        Console.ReadKey();
                        Console.Clear();
                        PrintBoard(game.Grid);
                    }
                }
                game.AddToGrid(row, column);

                if (game.CheckWinner()) // check winner after each move
                {
                    Console.Clear();
                    PrintBoard(game.Grid);
                    Console.WriteLine($"Winner is {(game.turn ? 'O' : 'X')}");
                    break;
                }
            }

            if (game.numOfTurns == 9 && !game.CheckWinner())
            {
                Console.WriteLine("Draw");
            }

        }

        static int GetBoundedIntInput(int minBoundry = int.MinValue, int maxBoundry = int.MaxValue, string prompt = "")
        {
            int res;
            do
            {
                Console.WriteLine(prompt);
                res = (int.TryParse(Console.ReadLine(), out res) ? res : -1);
            }
            while (res < minBoundry || res > maxBoundry);
            return res;
        }

        static void PrintBoard(char[,] Grid)
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Console.Write($" {Grid[i, j]} ");
                }
                Console.WriteLine();
            }
        }

    }
}