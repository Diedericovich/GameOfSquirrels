using System.Windows.Controls;

namespace _GameOfSquirrels
{
    public interface ITile
    {
        int LocationX { get; set; }
        int LocationY { get; set; }
        Border TileBorder { get; set; }

        int GetInteraction();
    }
}