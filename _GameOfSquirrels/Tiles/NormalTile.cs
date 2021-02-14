using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    internal class NormalTile : Tile
    {
        public NormalTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();
            BitmapImage img = new BitmapImage(new Uri(@"https://cdn.discordapp.com/attachments/809042663969652756/810162850668216330/stonepath.png"));
            ImageBrush image = new ImageBrush();
            image.ImageSource = img;
            image.Stretch = Stretch.Fill;
            TileBorder.Background = image;
            TileBorder.Margin = new Thickness(-1,10,-1,10);

            if (locationX == 0 && locationY == 1 || locationX == 0 && locationY == 3 || locationX == 0 && locationY == 5)
            {
                TileBorder.Margin = new Thickness(0, 10, 0, 0);
            }
            else if (locationX == 0 && locationY == 2 || locationX == 0 && locationY == 4 || locationX == 0 && locationY == 6)
            {
                TileBorder.Margin = new Thickness(0, 0, 0, 10);
            }
            else if (locationX == 7 && locationY == 0 || locationX == 7 && locationY == 2 || locationX == 7 && locationY == 4 || locationX == 7 && locationY == 6)
            {
                TileBorder.Margin = new Thickness(0, 10, 0, 0);
            }
            else if (locationX == 7 && locationY == 1 || locationX == 7 && locationY == 3 || locationX == 7 && locationY == 5 || locationX == 7 && locationY == 7)
            {
                TileBorder.Margin = new Thickness(0, 0, 0, 10);
            }

        }

        public int GetInteraction()
        {
            return 0;
        }
    }
}