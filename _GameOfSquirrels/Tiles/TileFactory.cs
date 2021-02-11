using System;
using System.Collections.Generic;
using System.Text;

namespace _GameOfSquirrels
{
    class TileFactory
    {
        public List<ITile> CreateTiles()
        {
            List<ITile> tiles = new List<ITile>();
            int counter = 3;
            for (int i = 0; i < 4; i++)
            {
                counter += 4;
                tiles.Add(new CatapultTile(counter,0));
            }

            return tiles;
        
        }
    }
}
