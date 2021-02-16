using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game Game;

        public MainWindow(int players)
        {
            InitializeComponent();
            Game = new Game();
            Game.StartGame(GridGame, players);
            lvPlayers.ItemsSource = Game.PlayerList;
            lblDiceResult.DataContext = Game;
            lblCurrentPlayer.DataContext = Game;
            lblCurrentRound.DataContext = Game;
        }

        private void TestButtonClick(object sender, RoutedEventArgs e)
        {
            Game.DoTurn();
        }
    }
}