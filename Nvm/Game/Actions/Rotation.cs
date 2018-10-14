using Nvm.Game.Data;

namespace Nvm.Game.Actions
{
    public enum Turn { Left, Right }

    public interface IRotation
    {
        void Execute(Turn turn);
    }

    public class Rotation : IRotation
    {
        readonly Player Player;

        public Rotation(Player player)
        {
            Player = player;
        }

        public void Execute(Turn turn)
        {
            if (turn == Turn.Left)
                Player.Direction = Player.Direction - 1 < 0 ? Direction.W : Player.Direction - 1;
            else
                Player.Direction = Player.Direction + 1 > Direction.W ? Direction.N : Player.Direction + 1;
        }
    }
}
