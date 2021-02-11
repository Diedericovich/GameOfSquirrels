namespace _GameOfSquirrels
{
    internal class FireTile : Tile
    {
        public FireTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
        }

        public override int GetInteraction()
        {
            return 0;
        }
    }
}