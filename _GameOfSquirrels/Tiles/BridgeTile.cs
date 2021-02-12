using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    internal class BridgeTile : Tile
    {
        public BridgeTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();


            BitmapImage img = new BitmapImage(new Uri(@"https://cdn.discordapp.com/attachments/809042663969652756/809745831732314152/TileGrass.png"));
            ImageBrush image = new ImageBrush();
            image.ImageSource = img;
            image.Stretch = Stretch.Fill;
            TileBorder.Background = image;
        }

        public override int GetInteraction()
        {
            MessageBox.Show("Going over a bridge! You move two spaces forward!");
            return 2;
        }
    }
}