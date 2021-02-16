namespace _GameOfSquirrels
{
    public class CatapultTile : Tile
    {
        public CatapultTile(int locationX, int locationY)
            : base(locationX, locationY)
        {
            Image = "https://i.ibb.co/5K12ZJQ/Catapult.png";
        }

        public override string GetInteractionMessage()
        {
            return "The catapult fires you 3 spaces forward!";
        }
    }
}