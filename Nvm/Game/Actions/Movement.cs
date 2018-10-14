using Nvm.Game.Policy;
using Nvm.Game.Data;
using System.Collections.Generic;

namespace Nvm.Game.Actions
{
    public interface IMovement
    {
        void Execute();
    }

    public class Movement : IMovement
    {
        readonly IReadOnlyDictionary<int, Point> DirectionToOffset = new Dictionary<int, Point> {
            { (int)Direction.N, new Point(0, 1) },
            { (int)Direction.E, new Point(1, 0) },
            { (int)Direction.S, new Point(0, -1) },
            { (int)Direction.W, new Point(-1, 0) }
        };
        readonly Player Player;
        readonly IMovePolicy Policy;

        public Movement(Player player, IMovePolicy policy)
        {
            Player = player;
            Policy = policy;
        }

        public void Execute()
        {
            Point newPosition = Player.Position + DirectionToOffset[(int)Player.Direction];
            if (Policy.Check(newPosition.X, newPosition.Y))
                Player.Position = newPosition;
        }
    }
}
