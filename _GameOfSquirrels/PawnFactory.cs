using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _GameOfSquirrels
{
    internal class PawnFactory
    {
        public ObservableCollection<IPawn> CreatePawns(int amount)
        {
            var playerList = new ObservableCollection<IPawn>();
            for (var i = 0; i < amount; i++)
            {
                playerList.Add(new Pawn(0, 0));

                switch (i)
                {
                    case 1:
                        playerList[1].Image = "https://i.ibb.co/J5SsBP5/squirrelred.png";
                        break;

                    case 2:
                        playerList[2].Image = "https://i.ibb.co/nmQrYtk/squirrelgreen.png";
                        break;

                    case 3:
                        playerList[3].Image = "https://i.ibb.co/4ZGJRyZ/squirrelorange.png";
                        break;

                    case 4:
                        playerList[4].Image = "https://i.ibb.co/h2PZjRh/squirrelpurple.png";
                        break;
                    case 5:
                        playerList[5].Image = "https://i.ibb.co/86C440j/squirrelyellow.png";
                        break;
                    case 6:
                        playerList[6].Image = "https://i.ibb.co/0DPX4Kx/squirrelpink.png";
                        break;
                    default:
                        break;
                }
            }
            return playerList;
        }
    }
}