using System.Windows;
using System.Windows.Media;

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
            //this.Background = new SolidColorBrush(Color.FromRgb(0, 115, 21));
            game = new Game(GridGame);
            game.GenerateBoard();
        }

        private void TestButtonClick(object sender, RoutedEventArgs e)
        {
            lblCurrentPlayer.Content = $"Current player: {game.CurrentPlayer+1}";
            game.DoTurn();
            lblDiceResult.Content = $"Dice result: {game.LastNumberRolled}";
            lblCurrentRound.Content = $"Current round: {game.RoundCounter+1}";
        }
    }
}