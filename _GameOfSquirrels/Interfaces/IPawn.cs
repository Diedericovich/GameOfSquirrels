using System.ComponentModel;

namespace _GameOfSquirrels
{
    public interface IPawn : INotifyPropertyChanged
    {
        bool GoingRight { get; set; }
        bool GoingUp { get; set; }
        string Image { get; set; }
        bool IsReversed { get; set; }
        bool IsSkippingNextTurn { get; set; }
        int LastRoll { get; set; }
        int LocationX { get; set; }
        int LocationY { get; set; }
        double Size { get; set; }
        int TurnsToSkip { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void Move(int x, int y);
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void MoveUp();
    }
}