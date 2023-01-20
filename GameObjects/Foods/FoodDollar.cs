using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char FoodSymbol = '$';
        private const int DefaultFoodPoints = 2;

        private const ConsoleColor DefaultColor = ConsoleColor.Green;

        public FoodDollar(Wall wall)
        : base(FoodSymbol, wall, DefaultFoodPoints,DefaultColor)
        {
        }
    }
}
