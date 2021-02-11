using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace _GameOfSquirrels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game game;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game(GridGame);
            game.GamePlay();

        }

        private void TestButtonClick(object sender, RoutedEventArgs e)
        {
            Dice dice = new Dice();
            int result = dice.RollDice(1, 7);
            Dicelabel.Content = result;
            game.MovePawn(result);
            game.CurrentPlayer++;
            if (game.CurrentPlayer > game.Playerlist.Count -1)
            {
                game.CurrentPlayer = 0;
            }

        }

       
    }
}