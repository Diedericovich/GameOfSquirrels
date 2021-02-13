using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _GameOfSquirrels
{
    public class Pawn : IPawn
    {
        public Pawn(int locationX, int locationY)
        {
            LocationX = locationX;
            LocationY = locationY;

            Ellipse = new Ellipse { Fill = Brushes.DarkRed, Height = 20, Width = 20 };
        }

        public int LastRoll { get; set; }

        public int LocationX { get; set; }

        public int LocationY { get; set; }

        public Ellipse Ellipse { get; set; }

        public void Move()
        {
            var dice = new Dice();
            var roll = dice.RollDice(1, 7);
            LastRoll = roll;
            LocationX += roll;
            Grid.SetColumn(Ellipse, LocationX);
        }

        public void Move(int x)
        {
            LocationX += x;
            Grid.SetColumn(Ellipse, LocationX);
        }
    }
}