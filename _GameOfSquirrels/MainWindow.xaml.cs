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
        public Game game;

        public MainWindow()
        {
            InitializeComponent();
            //this.Background = new SolidColorBrush(Color.FromRgb(0, 115, 21));
            game = new Game(GridGame);
            game.GenerateBoard();


            BitmapImage img = new BitmapImage(new Uri(@"https://cdn.discordapp.com/attachments/809042663969652756/810496364077252638/Overlay_test.png"));
            ImageBrush image = new ImageBrush();
            image.ImageSource = img;
            image.Stretch = Stretch.Fill;
            Overlay.Background = image;
        }

        private void TestButtonClick(object sender, RoutedEventArgs e)
        {
            lblCurrentPlayer.Content = $"Current player: {game.CurrentPlayer + 1}";
            game.DoTurn();
            lblDiceResult.Content = $"Dice result: {game.LastNumberRolled}";
            lblCurrentRound.Content = $"Current round: {game.RoundCounter + 1}";
            //game.UpdatePawnLocation();
        }


    }
}