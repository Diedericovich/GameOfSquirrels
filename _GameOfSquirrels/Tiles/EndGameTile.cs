namespace _GameOfSquirrels
{
    internal class EndGameTile : Tile
    {
        public EndGameTile(int locationX, int locationY)
        : base(locationX, locationY)
        {
            Image = "https://cdn.discordapp.com/attachments/809042663969652756/811247767694606396/transparent.png";
        }

        public override string GetInteractionMessage()
        {
            return "You win!";
        }
    }
}