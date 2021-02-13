using System.Windows.Controls;

namespace _GameOfSquirrels
{
    public abstract class Tile : ITile
    {
        public Tile(int locationX, int locationY)
        {
            LocationX = locationX;
            LocationY = locationY;
        }

        public int LocationX { get; set; }

        public int LocationY { get; set; }

        public Border TileBorder { get; set; }

        public virtual int GetInteraction()
        {
            return 0;
        }
    }
}