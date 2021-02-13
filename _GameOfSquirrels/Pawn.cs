using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _GameOfSquirrels
{
    public class Pawn : IPawn
    {
        private int _locationX;
        public int LastRoll { get; set; }
        public bool GoingUp { get; set; }
        public bool GoingRight { get; set; }
        public bool IsReversed { get; set; }

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
            GoingRight = true;
            IsReversed = false;
            LocationX = locationX;
            LocationY = locationY;

            //Ellipse = new Ellipse() { Fill = Brushes.DarkRed, Height = 50, Width = 50, };
            Ellipse = new Ellipse() {};


            BitmapImage img = new BitmapImage(new Uri(@"https://pngimg.com/uploads/squirrel/squirrel_PNG15804.png"));
            ImageBrush image = new ImageBrush();
            image.ImageSource = img;
            image.Stretch = Stretch.Fill;
            Ellipse.Fill = image;
            //TileBorder.Background = image;
            //TileBorder.Margin = new Thickness(1);
        }

        public void Move(int x, int y)
        {
            LocationX += x;
            LocationY += y;
            Grid.SetColumn(Ellipse, LocationX);
            Grid.SetRow(Ellipse, LocationY);
        }
    }
}