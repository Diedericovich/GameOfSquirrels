using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    public class BridgeTile : Tile
    {
        public BridgeTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();
            //TileBorder.Background = Brushes.LightSlateGray;

            BitmapImage img = new BitmapImage(new Uri(@"http://www.pngall.com/wp-content/uploads/2/Bridge-PNG-Picture.png"));
            ImageBrush image = new ImageBrush();
            image.ImageSource = img;
            image.Stretch = Stretch.Fill;
            TileBorder.Background = image;
            TileBorder.Margin = new Thickness(1);
        }

        public override int GetInteraction()
        {
            MessageBox.Show("Going over a bridge! You move two spaces forward!");
            return 2;
        }
    }
}