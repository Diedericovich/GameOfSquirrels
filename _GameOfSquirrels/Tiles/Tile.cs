namespace _GameOfSquirrels
{
    public abstract class Tile : ITile
    {
        public int LocationX { get; set; }

        public int LocationY { get; set; }
        public string Image { get; set; }

        protected Tile(int locationX, int locationY)
        {
            LocationX = locationX;
            LocationY = locationY;
            Image = "https://www.ros.org/wp-content/themes/dms/sections/mediabox/default.png";
        }

        public virtual string GetInteractionMessage()
        {
            return "";
        }
    }
}