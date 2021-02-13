using System;

namespace _GameOfSquirrels
{
    internal class Dice
    {
        private readonly Random dice = new Random();

        public int RollDice(int bottom, int top)
        {
            var result = dice.Next(bottom, top);

            return result;
        }
    }
}