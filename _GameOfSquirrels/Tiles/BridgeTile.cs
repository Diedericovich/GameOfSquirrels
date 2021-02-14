using System.Windows;

namespace _GameOfSquirrels
{
    internal class BridgeTile : Tile
    {
        public BridgeTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            //TileBorder.Background = Brushes.LightSlateGray;

            //BitmapImage img = new BitmapImage(new Uri(@"http://www.pngall.com/wp-content/uploads/2/Bridge-PNG-Picture.png"));
            //ImageBrush image = new ImageBrush();
            //image.ImageSource = img;
            //image.Stretch = Stretch.Fill;
            //TileBorder.Background = image;
            //TileBorder.Margin = new Thickness(1);
        }

        public override int GetInteraction()
        {
            MessageBox.Show("You take the bridge to the other side!");
            return 2;
        }
    }
}