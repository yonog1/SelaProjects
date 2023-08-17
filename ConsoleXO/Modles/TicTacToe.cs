using System;

namespace ConsoleXO
{
    internal class TicTacToe
    {
        public static char[,] gameBoard = new char[,] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };
        public void StartGame()
        {
            short numOfTurns = 0;
            bool turn = true;
            ShowBoard();
            bool winnerFound = false; // Flag to track if a winner has been found
            while (numOfTurns < 9)
            {
                if (numOfTurns >= 5)
                {
                    if (CheckWinner())
                    {
                        Console.WriteLine($"The winner is: {(!turn ? 'X' : 'O')}");
                        winnerFound = true; // Set the flag to true if a winner is found
                        break;
                    }
                }
                numOfTurns++;
                int[] userInput = GetCoordenates(turn ? 'X' : 'O');
                gameBoard[userInput[0], userInput[1]] = turn ? 'X' : 'O';
                turn = !turn;
                ShowBoard();
            }

            if (!winnerFound)
            {
                Console.WriteLine("It's a draw!");
            }
        }


        private static bool CheckWinner()
        {
            // Rows check
            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2] && gameBoard[i, 0] != '.')
                {
                    return true;
                }
            }

            // Columns check
            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[0, i] == gameBoard[1, i] && gameBoard[1, i] == gameBoard[2, i] && gameBoard[0, i] != '.')
                {
                    return true;
                }
            }

            // Diagonals check
            if ((gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2] && gameBoard[0, 0] != '.') ||
                (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0] && gameBoard[0, 2] != '.'))
            {
                return true;
            }

            return false;
        }


        private static bool IsPlaceAvailable(int x, int y)
        {
            if (gameBoard[x, y] == '.')
            {
                return true;
            }
            Console.Clear();
            Console.WriteLine($"This position ({x + 1},{y + 1}) is already taken, please choose another one. Press any key to continue:");
            Console.ReadKey();
            return false;
        }

        public static int[] GetCoordenates(char turn)
        {
            Console.Clear();
            int[] input = new int[2];
            int row;
            int column;
            Console.WriteLine($"Its {turn}'s turn");
            do
            {
                ShowBoard();
                do
                {
                    Console.WriteLine("Enter the row number [1-3]:");
                    row = (int.TryParse(Console.ReadLine(), out row) ? row : -1) - 1; //decrease -1 to fit array indexes
                }
                while (row < 0 || row > 2);
                do
                {
                    Console.WriteLine("Enter the column number [1-3]:");
                    column = (int.TryParse(Console.ReadLine(), out column) ? column : -1) - 1; //decrease -1 to fit array indexes
                }
                while (column < 0 || column > 2);
            }
            while (!IsPlaceAvailable(row, column));

            input[0] = row;
            input[1] = column;


            return input;
        }

        public static void ShowBoard()
        {
            Console.Clear();
            Console.WriteLine("Heres the board:");
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    Console.Write($" {gameBoard[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}