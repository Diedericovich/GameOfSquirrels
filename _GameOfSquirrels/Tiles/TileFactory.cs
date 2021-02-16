using System.Collections.Generic;

namespace _GameOfSquirrels
{
    internal class TileFactory
    {
        public List<ITile> CreateTiles(int boardHeight, int boardWidth)
        {
            var tiles = new List<ITile>
            {
                new BearTrapTile(4, 0),
                new TeleportTile(3, 0),
                new BridgeTile(1, 0),
                new SquirrelTile(2, 0),
                new CatapultTile(5, 0),
                new TunnelTile(4, 1),
                new SquirrelTile(6, 1),
                new SquirrelTile(2, 2),
                new SquirrelTile(5, 2),
                new CatapultTile(6, 2),
                new FireTile(0, 3),
                new SquirrelTile(1, 3),
                new SquirrelTile(4, 3),
                new CatapultTile(2, 4),
                new SquirrelTile(5, 4),
                new SquirrelTile(1, 5),
                new BridgeTile(6, 5),
                new BridgeTile(4, 6),
                new EndGameTile(0, 7),
                new CatapultTile(2, 7),
                new FireTile(5, 7),
                new SquirrelTile(7, 7)
            };

            return tiles;
        }
    }
}