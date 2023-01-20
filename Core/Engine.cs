namespace SimpleSnake.Core
{
    using SimpleSnake.Core.Contracts;
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects;
    using System;
    using System.Threading;

    public class Engine : IEngine
    {
        private const int DefaultSleepTime = 100;

        private Point[] pointsOfDirections;
        private Direction direction;
        private Snake snake;
        private Wall wall;
        private double sleepTime;
        private double difficultyStep = 0.01;

        private Engine()
        {
            this.sleepTime = DefaultSleepTime;
            this.pointsOfDirections = new Point[4];
        }
        public Engine(Wall wall, Snake snake)
            :this()
        {
            this.wall = wall;
            this.snake = snake;
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }
                bool canMove = snake.CanMove(this.pointsOfDirections[(int)direction]);
                if (!canMove)
                {
                    AskUserForRestart();
                }
                this.sleepTime -= difficultyStep;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void CreateDirections()
        {
            this.pointsOfDirections[(int)Direction.Right] = new Point(1, 0);
            this.pointsOfDirections[(int)Direction.Left] = new Point(-1, 0);
            this.pointsOfDirections[(int)Direction.Down] = new Point(0, 1);
            this.pointsOfDirections[(int)Direction.Up] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.RightArrow ||
                userInput.Key == ConsoleKey.D)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.LeftArrow ||
                userInput.Key == ConsoleKey.A)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow ||
                userInput.Key == ConsoleKey.S)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow ||
                userInput.Key == ConsoleKey.W)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Woud you like to continue? y/n");
            Console.SetCursorPosition(leftX, topY + 1);

            string input = Console.ReadLine();

            if (input.ToLower() == "y") 
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game Over");
            Environment.Exit(0);
        }
    }

}
