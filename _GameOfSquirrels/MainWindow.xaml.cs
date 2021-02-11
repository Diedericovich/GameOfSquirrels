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
        private Dice dice = new Dice();
        private Board board;
        public List<IPawn> Playerlist;
        public List<ITile> BoardTiles;

        public MainWindow()
        {
            InitializeComponent();
            board = new Board(GridGame, 0, 20);
            GridGame.ShowGridLines = true;
            //GridGame.Height = 30;
            TileFactory tileFactory = new TileFactory();
            BoardTiles = tileFactory.CreateTiles();
            foreach (var tile in BoardTiles)
            {
                GridGame.Children.Add(tile.TileBorder);
                Grid.SetColumn(tile.TileBorder, tile.LocationX);
            }

            //CatapultTile testtile = new CatapultTile(5, 5);
            //BoardTiles.Add(testtile);
            //GridGame.Children.Add(testtile.TileBorder);
            //Grid.SetColumn(testtile.TileBorder, testtile.LocationX);

            Pawn pawn = new Pawn(1, 1);
            GridGame.Children.Add(pawn.Ellipse);
            Grid.SetColumn(pawn.Ellipse, pawn.LocationX);
            Grid.SetRow(pawn.Ellipse, pawn.LocationY);
            Playerlist = new List<IPawn> { pawn };
        }

        private void TestButtonClick(object sender, RoutedEventArgs e)
        {
            Dice dice = new Dice();
            int result = dice.RollDice(1, 7);
            MovePawn(result);
        }

        public void MovePawn(int move)
        {
            Playerlist[0].Move(move);
            Dicelabel.Content = Playerlist[0].LastRoll;
            foreach (var item in BoardTiles)
            {
                if (Playerlist[0].LocationX == item.LocationX)
                {
                    MovePawn(item.GetInteraction());
                }
            }

            if (Playerlist[0].LocationX >= 20)
            {
                Playerlist[0].LocationX = 0;
                Grid.SetColumn(Playerlist[0].Ellipse, Playerlist[0].LocationX);
            }
        }
    }
}