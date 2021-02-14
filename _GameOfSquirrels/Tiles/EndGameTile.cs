using System.Windows;
using System.Windows.Controls;

namespace _GameOfSquirrels
{
    internal class EndGameTile : Tile
    {
        public EndGameTile(int locationX, int locationY)
        : base(locationX, locationY)
        {
            TileBorder = new Border();
            //TileBorder.Background = Brushes.LawnGreen;

            //BitmapImage img = new BitmapImage(new Uri(@"http://www.pngall.com/wp-content/uploads/5/Nuts-PNG-Pic.png"));
            //ImageBrush image = new ImageBrush();
            //image.ImageSource = img;
            //image.Stretch = Stretch.Fill;
            //TileBorder.Background = image;
            //TileBorder.Margin = new Thickness(1);
        }

        public override int GetInteraction()
        {
            MessageBox.Show("You win!");
            return 0;
        }
    }
}