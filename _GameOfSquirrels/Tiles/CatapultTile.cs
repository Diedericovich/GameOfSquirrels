using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _GameOfSquirrels.Tiles
{
    public class CatapultTile : Tile
    {
        public CatapultTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            TileBorder = new Border();
            TileBorder.Background = Brushes.IndianRed;
        }

        public override void InteractWith(IPawn pawn)
        {
            MessageBox.Show("Catapult! You will get thrown back three squares!");
            pawn.Move(-3);
        }
    }
}