namespace _GameOfSquirrels
{
    internal class BeaverTile : Tile
    {
        public BeaverTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
        }

        public override int GetInteraction()
        {
            return 0;
        }
    }
}