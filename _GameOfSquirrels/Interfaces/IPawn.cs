using System.Windows.Shapes;

namespace _GameOfSquirrels
{
    public interface IPawn
    {
        Ellipse Ellipse { get; set; }
        bool GoingRight { get; set; }
        bool GoingUp { get; set; }
        int LastRoll { get; set; }
        int LocationX { get; set; }
        int LocationY { get; set; }

        void Move(int x, int y);
    }
}