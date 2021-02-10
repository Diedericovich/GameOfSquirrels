using System.Windows.Shapes;

namespace _GameOfSquirrels
{
    public interface IPawn
    {
        Ellipse Ellipse { get; set; }
        int LocationX { get; set; }
        int LocationY { get; set; }

        void Move();

        void Move(int x);
    }
}