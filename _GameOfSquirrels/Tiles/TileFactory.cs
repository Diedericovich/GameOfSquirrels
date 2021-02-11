using System.Collections.Generic;

namespace _GameOfSquirrels
{
    internal class TileFactory
    {
        public List<ITile> CreateTiles()
        {
            List<ITile> tiles = new List<ITile>();
            //tiles.Add(new CatapultTile(4, 0));
            //tiles.Add(new BridgeTile(5, 0));
            //tiles.Add(new BridgeTile(7, 0));
            //tiles.Add(new CatapultTile(9, 0));

            int counter = 2;
            int counter1 = 0;
            for (int i = 0; i < 4; i++)
            {
                counter += 3;
                tiles.Add(new CatapultTile(counter, 0));
            }
            for (int i = 0; i < 2; i++)
            {
                counter1 += 2;
                tiles.Add(new BridgeTile(counter1, 0));
            }


            return tiles;
        }
    }
}