using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    public class CatapultTile : Tile
    {
        public CatapultTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();
            //TileBorder.Background = Brushes.IndianRed;

            BitmapImage img = new BitmapImage(new Uri(@"C:\Users\jens_\Pictures\Backgrounds\pngkit_cannon-png_1515093.png"));
            ImageBrush image = new ImageBrush();
            image.ImageSource = img;
            image.Stretch = Stretch.Fill;
            TileBorder.Background = image;
            TileBorder.Margin = new Thickness(1);
        }

        public override int GetInteraction()
        {
            MessageBox.Show("Catapult! You will get thrown back three squares!");
            return -3;
        }
    }
}