using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _GameOfSquirrels
{
    internal class BridgeTile : Tile
    {
        public BridgeTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();
            TileBorder.Background = Brushes.LightSlateGray;

            //BitmapImage img = new BitmapImage(new Uri(@"C:\Users\jens_\Pictures\Backgrounds\TestTile.png"));
            //ImageBrush image = new ImageBrush();
            //image.ImageSource = img;
            //image.Stretch = Stretch.Fill;
            //TileBorder.Background = image;
            //TileBorder.Margin = new Thickness(1);
        }

        public override int GetInteraction()
        {
            MessageBox.Show("Going over a bridge! You move two spaces forward!");
            return 2;
        }
    }
}