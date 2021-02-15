using System.Collections.Generic;
using System.Windows.Controls;

namespace _GameOfSquirrels
{
    public class Board
    {
        public List<IPawn> PlayerList;
        public List<ITile> TileList;
        public Grid BoardGrid;

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

        public Board(Grid grid, int height, int width)
        {
            BoardGrid = grid;
            MaxBoardHeight = height;
            MaxBoardWidth = width;
            SetSize();
        }

        public void SetSize()
        {
            for (int i = 0; i < MaxBoardWidth; i++)
            {
                BoardGrid.ColumnDefinitions.Add(new ColumnDefinition());
                //BoardGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(MaxBoardWidth) });
            }

            for (int i = 0; i < MaxBoardHeight; i++)
            {
                BoardGrid.RowDefinitions.Add(new RowDefinition());
                //BoardGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(MaxBoardWidth) });
            }
        }
    }
}