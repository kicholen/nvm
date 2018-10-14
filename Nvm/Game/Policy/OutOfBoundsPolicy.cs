using Nvm.Game.Policy;
using System;

namespace Nvm.Game.Actions.Mover.Policy
{
    public class OutOfBoundsPolicy : IMovePolicy
    {
        readonly int Size;

        public OutOfBoundsPolicy(int size)
        {
            if (size <= 0)
                throw new IncorrectSizeException();
            Size = size;
        }

        public bool Check(int x, int y)
        {
            return x >= 0 && x < Size && y >= 0 && y < Size;
        }
    }

    public class IncorrectSizeException : Exception {}
}
