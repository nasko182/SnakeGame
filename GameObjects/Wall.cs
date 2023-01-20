namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {

        private const char WallSymbol = '\u25A0';
        
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InicializeWallBorders();
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX <= this.LeftX; leftX++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY <= this.TopY; topY++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }

        private void InicializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);

            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }

        public bool IsPointOfWall(Point snakeElement)
        {
            return snakeElement.TopY == 0 || snakeElement.LeftX == 0
                || snakeElement.LeftX == this.LeftX - 1 || snakeElement.TopY == this.TopY;
        }

    }
}
