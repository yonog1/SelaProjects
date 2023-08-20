using BoardLogic;

namespace WinFormsGUI
{
    public partial class Form1 : Form
    {
        Board game = new();
        private readonly Button[] buttons;
        public Form1()
        {
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

                char cellContent = game.Grid[x, y];

                if (game.IsPlaceAvailable(x, y))
                {
                    game.AddToGrid(x, y);
                    clickedButton.Text = game.turn ? "O" : "X";
                }
                else
                {
                    MessageBox.Show($"This Slot is already taken by {(game.Grid[x, y] == 'X' ? 'X' : 'O')}");
                }
                Console.Clear();
                game.PrintBoard(game.Grid);
            }
            else
            {
                MessageBox.Show("Error has ocurred");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NewGame(object sender, EventArgs e)
        {
            game = new Board();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Text = "";
            }
            Console.Clear();
            game.PrintBoard(game.Grid);
        }
    }
}