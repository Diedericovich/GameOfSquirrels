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
            board = new Board(GridOuter, 0, 30);
            GridOuter.ShowGridLines = true;
            Pawn pawn = new Pawn(1,1);
            GridOuter.Children.Add(pawn.Ellipse);
            Grid.SetColumn(pawn.Ellipse, pawn.LocationX);
            Grid.SetRow(pawn.Ellipse, pawn.LocationY);
            pawn.Move();
            pawn.Move();
            pawn.Move();
            pawn.Move();
            pawn.Move();
            pawn.Move();
            pawn.Move();
            pawn.Move();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Test1.Content = dice.RollDice(1, 7);
        }
    }
}