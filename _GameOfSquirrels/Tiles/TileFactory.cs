using System.Collections.Generic;

namespace _GameOfSquirrels
{
    internal class TileFactory
    {
        public List<ITile> CreateTiles()
        {
            List<ITile> tiles = new List<ITile>();
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                counter += 4;
                tiles.Add(new CatapultTile(counter, 0));
            }
            for (int i = 0; i < 2; i++)
            {
                counter -= 1;
                tiles.Add(new BridgeTile(counter, 0));
            }

            return tiles;
        }
    }
}