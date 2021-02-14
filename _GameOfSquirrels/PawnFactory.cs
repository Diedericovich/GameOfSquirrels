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
                playerList.Add(new Pawn(0, 0));

                switch (i)
                {
                    case 0:
                        //playerList[0].Ellipse.Fill = Brushes.Red;
                        break;

                    case 1:
                        //playerList[1].Ellipse.Fill = Brushes.Blue;
                        break;

                    case 2:
                        //playerList[2].Ellipse.Fill = Brushes.Pink;
                        break;

                    case 3:
                        //playerList[3].Ellipse.Fill = Brushes.Yellow;
                        break;

                    default:
                        break;
                }
            }
            return playerList;
        }
    }
}