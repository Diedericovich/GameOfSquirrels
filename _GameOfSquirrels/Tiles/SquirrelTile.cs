using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    public class SquirrelTile : Tile
    {
        public SquirrelTile(int locationX, int locationY)
                        : base(locationX, locationY)
        {
            
            //TileBorder.Background = Brushes.BlanchedAlmond;
            //BitmapImage img = new BitmapImage(new Uri(@"C:\Users\jens_\Pictures\Backgrounds\kisspng-scratte-bear-squirrel-drawing-scrat-by-miserysteaparty-on-deviantart-5c5ad24d1dcd87.2096942815494559491221.png"));
            //ImageBrush image = new ImageBrush();
            //image.ImageSource = img;
            //image.Stretch = Stretch.Fill;
            //TileBorder.Background = image;
            //TileBorder.Margin = new Thickness(1);
        }

        public override int GetInteraction()
        {
            MessageBox.Show("A friendly squirrel helps you move forward again!");
            return 0;
        }
    }
}