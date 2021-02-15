using System.Windows.Controls;

namespace _GameOfSquirrels
{
    internal class Board
    {
        public Grid BoardGrid;

        public int MinBoardHeight { get; set; }

        public int MinBoardWidth { get; set; }

        public int MaxBoardHeight { get; set; }

        public int MaxBoardWidth { get; set; }

        public Board(Grid grid, int height, int width)
        {
            BoardGrid = grid;
            MaxBoardHeight = height;
            MaxBoardWidth = width;
            SetSize();
        }

        private void SetSize()
        {
            for (var i = 0; i < MaxBoardWidth; i++)
            {
                BoardGrid.ColumnDefinitions.Add(new ColumnDefinition());
                //BoardGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(MaxBoardWidth) });
            }

            for (var i = 0; i < MaxBoardHeight; i++)
            {
                BoardGrid.RowDefinitions.Add(new RowDefinition());
                //BoardGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(MaxBoardWidth) });
            }
        }
    }
}