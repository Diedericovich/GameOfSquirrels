using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public MainWindow()
        {
            InitializeComponent();
            board = new Board(GridGame, 0, 10);
            GridGame.ShowGridLines = true;
            GridGame.Height = 30;

            Pawn pawn = new Pawn(1, 1);
            GridGame.Children.Add(pawn.Ellipse);
            Grid.SetColumn(pawn.Ellipse, pawn.LocationX);
            Grid.SetRow(pawn.Ellipse, pawn.LocationY);

            Playerlist = new List<IPawn> { pawn };

            CatapultTile testtile = new CatapultTile(5, 5);
            GridGame.Children.Add(testtile.TileBorder);
            Grid.SetColumn(testtile.TileBorder, testtile.LocationX);
        }

        private void TestButtonClick(object sender, RoutedEventArgs e)
        {
            Playerlist[0].Move();
        }
    }
}