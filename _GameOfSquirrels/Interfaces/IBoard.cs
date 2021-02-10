namespace _GameOfSquirrels
{
    public interface IBoard
    {
        int MaxBoardHeight { get; set; }
        int MaxBoardWidth { get; set; }
        int MinBoardHeight { get; set; }
        int MinBoardWidth { get; set; }

        void SetSize();
    }
}