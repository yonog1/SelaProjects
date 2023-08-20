using BoardLogic;

namespace WinFormsGUI
{
    public partial class Form1 : Form
    {
        Board game = new();
        private readonly Button[] buttons;
        public Form1()
        {
            if (game.winnerFound)
            {
                MessageBox.Show($"{(!game.turn ? "O" : "X")}");
            }
            InitializeComponent();
            game = new Board();
            buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += HandleButtonClicked;
                buttons[i].Text = "";
                buttons[i].Tag = i;
            }
        }

        private void HandleButtonClicked(object? sender, EventArgs e)
        {

            if (sender != null)
            {
                Button clickedButton = (Button)sender;
                int buttonIndex = (int)clickedButton.Tag;
                int x = buttonIndex % 3;   // column index (0, 1, or 2)
                int y = buttonIndex / 3;   // row index (0, 1, or 2)


                if (game.IsPlaceAvailable(x, y))
                {
                    if (!game.winnerFound)
                    {
                        game.AddToGrid(x, y);
                        clickedButton.Text = game.turn ? "O" : "X";
                    }
                    if (game.numOfTurns >= 5)
                    {
                        if (game.CheckWinner())
                        {
                            MessageBox.Show($"Winner is {(game.turn ? "O" : "X")}!\nClick \"NewGame\" to reset the board.");
                            game.winnerFound = true;
                        }
                        else if (game.numOfTurns == 9 && game.CheckWinner() == false)
                        {
                            MessageBox.Show("Draw");
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"This Slot is already taken by {(game.Grid[x, y] == 'X' ? 'X' : 'O')}");
                }

            }
            else
            {
                MessageBox.Show("Error has ocurred");
            }
        }

        private void NewGame(object sender, EventArgs e)
        {
            game = new Board();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = "";
            }
        }
    }
}