using System;

namespace _GameOfSquirrels
{
    public class Dice
    {
        private readonly Random _dice = new Random();

        public int RollDice(int bottom, int top)
        {
            var result = _dice.Next(bottom, top);

            return result;
        }
    }
}