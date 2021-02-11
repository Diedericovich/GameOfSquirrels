using System.Collections.Generic;

namespace _GameOfSquirrels
{
    internal class PawnFactory
    {
        public List<IPawn> CreatePawns(int amount)
        {
            List<IPawn> playerList = new List<IPawn>();
            for (int i = 0; i < amount; i++)
            {
                playerList.Add(new Pawn(1, 1));
            }
            return playerList;
        }
    }
}