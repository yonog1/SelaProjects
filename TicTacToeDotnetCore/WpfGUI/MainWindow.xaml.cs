using BoardLogic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfGUI
{
    public partial class MainWindow : Window
    {
        public bool turn = false;
        //init new game?
        Board game = new Board();
        private readonly Button[] buttons;
        private bool[] clicked = new bool[9];

        public MainWindow()
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
                buttons[i].Click += Button_Click;
                buttons[i].Content = "";
                buttons[i].Tag = i;
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                Button clickedButton = (Button)sender;
                int idx = int.Parse(clickedButton.Tag.ToString());
                if (clicked[idx]) { return; }
                clicked[idx] = true;
                int buttonIndex = (int)clickedButton.Tag;
                int x = buttonIndex % 3;   // column index (0, 1, or 2)
                int y = buttonIndex / 3;   // row index (0, 1, or 2)

                if (!game.winnerFound)
                {
                    game.AddToGrid(x, y);
                    clickedButton.Content = game.turn ? "O" : "X";
                }

                if (game.numOfTurns >= 5)
                {
                    if (game.CheckWinner())
                    {
                        game.winnerFound = true;
                        var result = MessageBox.Show($"Winner is {(game.turn ? "O" : "X")}!\nClick \"Ok\" to reset the board.", "Game Over", MessageBoxButton.OKCancel);
                        if (result == MessageBoxResult.OK)
                        {
                            // This is used to reset the game state on the UI thread, ensuring that it occurs after the message box is closed.
                            Application.Current.Dispatcher.BeginInvoke((Action)ResetGame, System.Windows.Threading.DispatcherPriority.Background);
                        }
                    }
                    else if (game.numOfTurns == 9 && game.CheckWinner() == false)
                    {
                        MessageBox.Show("Draw");
                        Application.Current.Dispatcher.BeginInvoke((Action)ResetGame, System.Windows.Threading.DispatcherPriority.Background);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error has occurred");
            }
        }


        private void ResetGame()
        {
            game = new Board();
            foreach (var button in buttons)
            {
                button.Content = "";
            }
            for (int i = 0; i < clicked.Length; i++)
            {
                clicked[i] = false;
            }
        }
    }
}
