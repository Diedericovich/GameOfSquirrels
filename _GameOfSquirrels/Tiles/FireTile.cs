using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _GameOfSquirrels
{
    internal class FireTile : Tile
    {
        public FireTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();

            BitmapImage img = new BitmapImage(new Uri(@"https://cdn.discordapp.com/attachments/809042663969652756/810852485576785920/Fire.png"));
            ImageBrush imageBrush = new ImageBrush { ImageSource = img, Stretch = Stretch.UniformToFill };
            TileBorder.Background = imageBrush;
            TileBorder.Margin = new Thickness(35);
        }

        public override int GetInteraction()
        {
            MessageBox.Show("Fire! Move back to the start!");
            return 0;
        }
    }
}