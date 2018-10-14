using Nvm.Game.Actions.Mover.Policy;
using Nvm.Game.Data;
using Nvm.Game.Handler;
using Nvm.Game.Parser;

namespace Nvm.Game
{
    public class Game
    {
        public const Direction StartDirection = Direction.N;
        public const int StartX = 0;
        public const int StartY = 0;
        public const int Size = 5;

        public IHandler Handler { get; }
        public Player Player { get; }
        public SyntaxParser Parser { get; }

        public Game()
        {
            Player = new Player { Direction = StartDirection, Position = new Point(StartX, StartY) };
            Handler = new Handler.Handler(new Actions.Movement(Player, new OutOfBoundsPolicy(Size)), new Actions.Rotation(Player));
            Parser = new SyntaxParser(Handler);
        }

        public void OnInput(string input)
        {
            Parser.Parse(input);
        }
    }
}
