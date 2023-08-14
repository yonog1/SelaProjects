using System;

namespace ConsoleXO
{
    internal class TicTacToe
    {
        public static char[,] gameBoard = new char[,] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };
        public void StartGame()
        {
            bool winner = false;
            bool turn = true;
            ShowBoard();
            while (!winner)
            {
                int[] userInput = GetCoordenates(turn ? 'X' : 'O');
                gameBoard[userInput[0], userInput[1]] = turn ? 'X' : 'O';
                turn = !turn;
                ShowBoard();
            }
        }

        private static void CheckWinner()
        {
            /*TODO
            check if there is a winner on the board, either declaratively or recursively (more complex)
            */
        }

        private static bool IsPlaceAvailable(int x, int y)
        {
            if (gameBoard[x, y] == '.')
            {
                return true;
            }
            Console.Clear();
            Console.WriteLine("This position is already taken, please choose another one. Press any key to continue:");
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