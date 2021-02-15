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

        public MainWindow()
        {
            InitializeComponent();
            //this.Background = new SolidColorBrush(Color.FromRgb(0, 115, 21));
            Game = new Game(GridGame);
            Game.GenerateBoard();
            lblDiceResult.DataContext = Game;
            lblCurrentPlayer.DataContext = Game;
            lblCurrentRound.DataContext = Game;

            var img = new BitmapImage(new Uri(@"https://cdn.discordapp.com/attachments/809042663969652756/810496364077252638/Overlay_test.png"));
            var image = new ImageBrush { ImageSource = img, Stretch = Stretch.Fill };
            Overlay.Background = image;
        }

        private void TestButtonClick(object sender, RoutedEventArgs e)
        {
            Game.DoTurn();
        }
    }
}