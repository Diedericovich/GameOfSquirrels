using System.ComponentModel;
using System.Windows.Controls;

namespace _GameOfSquirrels
{
    public interface IGame
    {
        int CurrentPlayer { get; set; }
        Grid GridGame { get; set; }
        int LastNumberRolled { get; set; }
        int RoundCounter { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        void DoTurn();

        void MovePawn(int roll, IPawn pawn);

        void StartGame(Grid grid, int players);
    }
}