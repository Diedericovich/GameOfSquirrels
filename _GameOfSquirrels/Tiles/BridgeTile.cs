using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    public class BridgeTile : Tile
    {
        public BridgeTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder.Background = Brushes.LightSlateGray;

            var img = new BitmapImage(new Uri(@"http://www.pngall.com/wp-content/uploads/2/Bridge-PNG-Picture.png"));
            var image = new ImageBrush { ImageSource = img, Stretch = Stretch.Fill };
            TileBorder.Background = image;
            TileBorder.Margin = new Thickness(1);
        }

        public override int GetInteraction()
        {
            MessageBox.Show("You take the bridge to the other side!");
            return 2;
        }
    }
}