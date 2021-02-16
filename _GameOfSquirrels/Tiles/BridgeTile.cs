namespace _GameOfSquirrels
{
    public class BridgeTile : Tile
    {
        public BridgeTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
        }

        public override string GetInteractionMessage()
        {
            return "You take the bridge to the other side!";
        }
    }
}