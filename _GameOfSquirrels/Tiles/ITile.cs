namespace _GameOfSquirrels
{
    public interface ITile
    {
        int LocationX { get; set; }
        int LocationY { get; set; }
        string Image { get; set; }

        string GetInteractionMessage();
    }
}