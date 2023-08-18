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
                    if (game.CheckWinner())
                    {
                        Console.WriteLine($"Winner is {(game.turn ? 'O' : 'X')}"); // print the symbol played before current since the winner would have made the winning move before the one currently set
                        game.winnerFound = true;
                        break;
                    }
                    else if (game.numOfTurns == 9)
                    {
                        Console.WriteLine("Its a draw!");
                        break;
                    }
                }

                int row;
                int column;
                // Get user input from console
                while (true)
                {
                    game.PrintBoard();
                    do
                    {
                        Console.WriteLine("Enter the row number [1-3]:");
                        row = (int.TryParse(Console.ReadLine(), out row) ? row : -1) - 1; // Decrease -1 to fit array indexes
                    }
                    while (row < 0 || row > 2);

                    do
                    {
                        Console.WriteLine("Enter the column number [1-3]:");
                        column = (int.TryParse(Console.ReadLine(), out column) ? column : -1) - 1; // Decrease -1 to fit array indexes
                    }
                    while (column < 0 || column > 2);

                    if (game.IsPlaceAvailable(row, column))
                    {
                        break;
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
    }
}