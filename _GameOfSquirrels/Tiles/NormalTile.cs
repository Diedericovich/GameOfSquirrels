using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels.Tiles
{
    internal class NormalTile : Tile
    {
        public NormalTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();
            BitmapImage img = new BitmapImage(new Uri(@"https://cdn.discordapp.com/attachments/809042663969652756/809745831732314152/TileGrass.png"));
            ImageBrush image = new ImageBrush();
            image.ImageSource = img;
            image.Stretch = Stretch.Fill;
            TileBorder.Background = image;
            TileBorder.Margin = new Thickness(1);
        }

        public int GetInteraction()
        {
            return 0;
        }
    }
}