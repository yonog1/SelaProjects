namespace BoardLogic
{
    public class Board
    {
        public char[,] Grid { get; private set; }
        public short numOfTurns;
        public bool turn;
        public bool winnerFound;

        public Board()
        {
            Grid = new char[3, 3] { { '.', '.', '.' }, { '.', '.', '.' }, { '.', '.', '.' } };
            numOfTurns = 0;
            turn = true;
            winnerFound = false;
        }

        public void PrintBoard(char[,] Grid)
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Console.Write($" {Grid[j, i]} ");
                }
                Console.WriteLine();
            }
        }

        public void AddToGrid(int x, int y)
        {
            Grid[x, y] = turn ? 'X' : 'O';
            numOfTurns++;
            turn = !turn;
        }

        public bool IsPlaceAvailable(int x, int y)
        {
            if (Grid[x, y] == '.')
            {
                return true;
            }
            return false;
        }

        public bool CheckWinner()
        {
            // Rows check
            for (int i = 0; i < 3; i++)
            {
                if (Grid[i, 0] == Grid[i, 1] && Grid[i, 1] == Grid[i, 2] && Grid[i, 0] != '.')
                {
                    return true;
                }
            }

            // Columns check
            for (int i = 0; i < 3; i++)
            {
                if (Grid[0, i] == Grid[1, i] && Grid[1, i] == Grid[2, i] && Grid[0, i] != '.')
                {
                    return true;
                }
            }

            // Diagonals check
            if ((Grid[0, 0] == Grid[1, 1] && Grid[1, 1] == Grid[2, 2] && Grid[0, 0] != '.') ||
                (Grid[0, 2] == Grid[1, 1] && Grid[1, 1] == Grid[2, 0] && Grid[0, 2] != '.'))
            {
                return true;
            }

            return false;
        }
    }

}
