namespace Nvm.Game.Data
{
    public enum Direction { N, E, S, W }

    public class Player
    {
        public Direction Direction;
        public Point Position;

        public override string ToString()
        {
            return $"{Position} {Direction}";
        }
    }
}
