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
                if (game.numOfTurns >= 5) // check winner from 5 turns, there cant be a winner before
                {
                    if (game.CheckWinner()) // get out of game loop if theres a winner
                    {
                        Console.WriteLine($"Winner is {(game.turn ? 'O' : 'X')}"); // print the symbol played before current since the winner would have made the winning move before the one currently set
                        game.winnerFound = true;
                        break;
                    }
                }

                int row;
                int column;

                while (true) // Get user input from console until its valid
                {
                    game.PrintBoard();
                    // offset min/max boundries by +1 for user readability and decrese by -1 to fit array indexes
                    row = GetBoundedIntInput(1, 3, "Enter the row number [1-3]:") - 1;
                    column = GetBoundedIntInput(1, 3, "Enter the column number [1-3]:") - 1;

                    if (game.IsPlaceAvailable(row, column))
                    {
                        break; // if input is valid the game loop will continue
                    }
                    else
                    {
                        Console.WriteLine($"This position ({row + 1},{column + 1}) is already taken, please choose another one. Press any key to continue:");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                game.AddToGrid(row, column);
            }

            if (!game.winnerFound)
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
    }
}