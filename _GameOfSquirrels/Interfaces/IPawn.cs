using System.Windows.Shapes;

namespace _GameOfSquirrels
{
    public interface IPawn
    {
        Ellipse Ellipse { get; set; }
        bool GoingRight { get; set; }
        bool GoingUp { get; set; }
        bool IsReversed { get; set; }
        bool IsSkippingNextTurn { get; set; }
        int LastRoll { get; set; }
        int LocationX { get; set; }
        int LocationY { get; set; }
        int TurnsToSkip { get; set; }

        void Move(int x, int y);
    }
}