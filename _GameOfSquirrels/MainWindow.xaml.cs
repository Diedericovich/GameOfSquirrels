using System.Windows;

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

        private void ToggleGrid(object sender, RoutedEventArgs e)
        {
            if (GridGame.ShowGridLines)
            {
                GridGame.ShowGridLines = false;
            }
            else
            {
                GridGame.ShowGridLines = true;
            }
        }

        private void ToggleLegend(object sender, RoutedEventArgs e)
        {
            if (LegendOverlay.Visibility == Visibility.Collapsed)
            {
                LegendOverlay.Visibility = Visibility.Visible;
            }
            else
            {
                LegendOverlay.Visibility = Visibility.Collapsed;
            }
        }

        private void ToggleCredits(object sender, RoutedEventArgs e)
        {
            if (CreditsOverlay.Visibility == Visibility.Collapsed)
            {
                CreditsOverlay.Visibility = Visibility.Visible;
            }
            else
            {
                CreditsOverlay.Visibility = Visibility.Collapsed;
            }
        }
    }
}