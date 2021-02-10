using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _GameOfSquirrels
{
    class Pawn : IPawn
    {
        private int _locationX;

        public int LocationX
        {
            get { return _locationX; }
            set { _locationX = value; }
        }

        private int _locationY;

        public int LocationY
        {
            get { return _locationY; }
            set { _locationY = value; }
        }

        private Ellipse _ellipse;

        public Ellipse Ellipse
        {
            get { return _ellipse; }
            set { _ellipse = value; }
        }

        public Pawn(int locationX, int locationY)
        {
            LocationX = locationX;
            LocationY = locationY;
            Ellipse = new Ellipse() { Fill = Brushes.BlueViolet };

        }

        public void Move()
        {
            Dice dice = new Dice();
            LocationX += dice.RollDice(1,7);
            Grid.SetColumn(Ellipse, LocationX);
        }
    }
}
