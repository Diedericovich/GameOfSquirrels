namespace _GameOfSquirrels
{
    interface ITile
    {
        int LocationX { get; set; }
        int LocationY { get; set; }

        void InteractWith(Pawn pawn);
    }
}