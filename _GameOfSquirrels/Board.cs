using System.Windows.Controls;

namespace _GameOfSquirrels
{
    public class Board
    {
        private Grid _boardGrid;

        private int MaxBoardHeight { get; set; }

        private int MaxBoardWidth { get; set; }

        public Board(Grid grid, int height, int width)
        {
            _boardGrid = grid;
            MaxBoardHeight = height;
            MaxBoardWidth = width;
            SetSize();
        }

        private void SetSize()
        {
            for (var i = 0; i < MaxBoardWidth; i++)
            {
                _boardGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (var i = 0; i < MaxBoardHeight; i++)
            {
                _boardGrid.RowDefinitions.Add(new RowDefinition());
            }
        }
    }
}