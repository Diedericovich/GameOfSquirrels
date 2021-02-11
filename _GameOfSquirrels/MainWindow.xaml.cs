using System.Windows;

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
            game.GenerateBoard();
        }

        private void TestButtonClick(object sender, RoutedEventArgs e)
        {
            game.DoTurn();
        }
    }
}