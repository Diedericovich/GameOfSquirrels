using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using _GameOfSquirrels.Tiles;

namespace _GameOfSquirrels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dice dice = new Dice();
        private Board board;
        public List<IPawn> Playerlist;
        public List<ITile> BoardTiles;

        public MainWindow()
        {
            InitializeComponent();
            board = new Board(GridGame, 20, 20);
            GridGame.ShowGridLines = true;
            //GridGame.Height = 30;

            BoardTiles = new List<ITile>();
            CatapultTile testtile = new CatapultTile(5, 5);
            BoardTiles.Add(testtile);
            GridGame.Children.Add(testtile.TileBorder);
            Grid.SetColumn(testtile.TileBorder, testtile.LocationX);

            Pawn pawn = new Pawn(1, 1);
            GridGame.Children.Add(pawn.Ellipse);
            Grid.SetColumn(pawn.Ellipse, pawn.LocationX);
            Grid.SetRow(pawn.Ellipse, pawn.LocationY);
            Playerlist = new List<IPawn> { pawn };
        }

        private void TestButtonClick(object sender, RoutedEventArgs e)
        {
            Playerlist[0].Move();
            Dicelabel.Content = Playerlist[0].LastRoll;
            if (Playerlist[0].LocationX == BoardTiles[0].LocationX)
            {
                BoardTiles[0].InteractWith(Playerlist[0]);
            }

            if (Playerlist[0].LocationX >= 20)
            {
                Playerlist[0].LocationX = 0;
                Grid.SetColumn(Playerlist[0].Ellipse, Playerlist[0].LocationX);
            }
        }
    }
}