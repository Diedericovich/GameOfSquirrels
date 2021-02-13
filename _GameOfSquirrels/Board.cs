using System.Collections.Generic;
using System.Windows.Controls;

namespace _GameOfSquirrels
{
    internal class Board
    {
        public Grid BoardGrid;
        public List<IPawn> PlayerList;

        public List<ITile> TileList;

        public Board(Grid grid, int height, int width)
        {
            BoardGrid = grid;
            MaxBoardHeight = height;
            MaxBoardWidth = width;
            SetSize();
        }

        public int MinBoardHeight { get; set; }

        public int MinBoardWidth { get; set; }

        public int MaxBoardHeight { get; set; }

        public int MaxBoardWidth { get; set; }

        public void SetSize()
        {
            for (var i = 0; i < MaxBoardWidth; i++) BoardGrid.ColumnDefinitions.Add(new ColumnDefinition());

            for (var i = 0; i < MaxBoardHeight; i++) BoardGrid.RowDefinitions.Add(new RowDefinition());
        }
    }
}