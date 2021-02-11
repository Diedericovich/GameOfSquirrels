using System.Windows.Controls;

namespace _GameOfSquirrels
{
    public abstract class Tile : ITile
    {
        private int _locationX;

        public int LocationX
        {
            get { return _locationX; }
            set { _locationX = value; }
        }

        private int _locationY;

        public int LocationY
        {
            get { return _locationY; }
            set { _locationY = value; }
        }

        public Border TileBorder { get; set; }

        public Tile(int locationX, int locationY)
        {
            LocationX = locationX;
            LocationY = locationY;
        }

        public virtual int GetInteraction()
        {
            return 0;
        }
    }
}