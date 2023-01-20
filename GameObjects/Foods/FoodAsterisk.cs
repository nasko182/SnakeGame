using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk: Food
    { 
        private const char FoodSymbol = '*';
        private const int DefaultFoodPoints = 1;
        private const ConsoleColor DefaultColor = ConsoleColor.Red;

        public FoodAsterisk(Wall wall) 
        : base(FoodSymbol, wall, DefaultFoodPoints,DefaultColor)
        {
        }
    }
}
