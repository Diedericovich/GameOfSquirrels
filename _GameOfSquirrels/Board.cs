using System;
using System.Collections.Generic;
using System.Text;

namespace _GameOfSquirrels
{
    class Board
    {
        private int _minBoardHeight;

        public int MinBoardHeight
        {
            get { return _minBoardHeight; }
            set { _minBoardHeight = value; }
        }

        private int _minBoardWidth;

        public int MinBoardWidth
        {
            get { return _minBoardWidth; }
            set { _minBoardWidth = value; }
        }

        private int _maxBoardHeight;

        public int MaxBoardHeight
        {
            get { return _maxBoardHeight; }
            set { _maxBoardHeight = value; }
        }

        private int _maxBoardWidth;

        public int MaxBoardWidth
        {
            get { return _maxBoardWidth; }
            set { _maxBoardWidth = value; }
        }

        public List<IPawn> PlayerList;


        public List<ITile> TileList;

        public Board(List<IPawn> players, List<ITile> tiles)
        {
            PlayerList = players;
            TileList = tiles;
        }






    }
}
