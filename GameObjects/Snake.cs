namespace SimpleSnake.GameObjects
{
    using SimpleSnake.GameObjects.Foods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';
        private const int SnakeLenght = 6;
        private const char emptySpace = ' ';

        private readonly Queue<Point> snakeElements;
        private Wall wall;
        private Food[] food;


        private int foodIndex;
        private int nextLeftX;
        private int nextTopY;


        public Snake(Wall wall)
        {
            this.snakeElements = new Queue<Point>();
            this.wall = wall;
            this.food= new Food[3];
            this.foodIndex = RandomFoodNumber;
            this.GetFoods();
            this.CreateSnake();
        }
        private int RandomFoodNumber=>
            new Random().Next(0,this.food.Length);

        private void CreateSnake()
        {
            for(int topY=1;topY<=SnakeLenght;topY++)
            {
                this.snakeElements.Enqueue(new Point(2,topY));
            }
        }

        private void GetFoods()
        {
            this.food[0] = new FoodAsterisk(this.wall);
            this.food[1] = new FoodDollar(this.wall);
            this.food[2] = new FoodHash(this.wall);

            this.SpawnFood();
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        public bool CanMove(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();

            GetNextPoint(direction, currentSnakeHead);

            bool hasSankeOverlapped = this.snakeElements
                .Any(e => e.LeftX == this.nextLeftX && e.TopY == this.nextTopY);

            if (hasSankeOverlapped)
            {
                return false;
            }

            Point newSnakeHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(SnakeSymbol);

            if (food[foodIndex].IsFoodPoint(newSnakeHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snaleTail = this.snakeElements.Dequeue();
            snaleTail.Draw(emptySpace);

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int snakeLenght = food[foodIndex].FoodPoints;

            for (int i = 0; i < snakeLenght; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            SpawnFood();

        }

        private void SpawnFood()
        {
            this.foodIndex = this.RandomFoodNumber;
            this.food[foodIndex].SetRandomPosition(this.snakeElements);
        }
    }
}
