using Nvm.Game.Actions;

namespace Nvm.Game.Handler
{
    public interface IHandler
    {
        void HandleL();
        void HandleR();
        void HandleM();
    }

    public class Handler : IHandler
    {
        readonly IMovement Movement;
        readonly IRotation Rotation;

        public Handler(IMovement mover, IRotation rotation)
        {
            Movement = mover;
            Rotation = rotation;
        }

        public void HandleM()
        {
            Movement.Execute();
        }

        public void HandleL()
        {
            Rotation.Execute(Turn.Left);
        }

        public void HandleR()
        {
            Rotation.Execute(Turn.Right);
        }
    }
}
