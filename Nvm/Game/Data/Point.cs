namespace Nvm.Game.Data
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point c1, Point c2)
        {
            return new Point(c1.X + c2.X, c1.Y + c2.Y);
        }

        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }
}
