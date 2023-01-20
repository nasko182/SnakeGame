using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int DefaultFoodPoints = 3;

        private const ConsoleColor DefaultColor = ConsoleColor.DarkCyan;

        public FoodHash(Wall wall)
        : base(FoodSymbol, wall, DefaultFoodPoints, DefaultColor)
        {
        }
    }
}
