using System.Collections.Generic;

namespace _GameOfSquirrels
{
    internal class TileFactory
    {
        public List<ITile> CreateTiles()
        {
            List<ITile> tiles = new List<ITile>();

            for (int i = 0; i < 4; i++)
            {
                tiles.Add(new SquirrelTile(3, i));
                tiles.Add(new CatapultTile(4, i));
                tiles.Add(new BridgeTile(5, i));
                tiles.Add(new BridgeTile(6, i));
                tiles.Add(new CatapultTile(8, i));
                tiles.Add(new FireTile(10, i));
                tiles.Add(new SquirrelTile(12, i));
                tiles.Add(new FireTile(13, i));
                tiles.Add(new BridgeTile(15, i));
                tiles.Add(new BridgeTile(20, i));
                tiles.Add(new BridgeTile(21, i));
                tiles.Add(new CatapultTile(25, i));
                tiles.Add(new FireTile(26, i));
                tiles.Add(new SquirrelTile(28, i));
                tiles.Add(new FireTile(36, i));
                tiles.Add(new BridgeTile(37, i));
                //tiles.Add(new CatapultTile(17, i));
                //tiles.Add(new BridgeTile(3, i));
                //tiles.Add(new BridgeTile(5, i));
                //tiles.Add(new BridgeTile(7, i));
                //tiles.Add(new BridgeTile(9, i));
                //tiles.Add(new BridgeTile(11, i));
                //tiles.Add(new BridgeTile(13, i));
                //tiles.Add(new BridgeTile(5, i));
            }

            //int counter = 2;
            //int counter1 = 0;
            //for (int i = 0; i < 4; i++)
            //{
            //    counter += 3;
            //    tiles.Add(new CatapultTile(counter, 0));
            //}
            //for (int i = 0; i < 2; i++)
            //{
            //    counter1 += 2;
            //    tiles.Add(new BridgeTile(counter1, 0));
            //}

            return tiles;
        }
    }
}