using Nvm.Game.Handler;
using System;

namespace Nvm.Game.Parser
{
    public class SyntaxParser
    {
        readonly IHandler Handler;

        public SyntaxParser(IHandler handler)
        {
            Handler = handler;
        }

        public void Parse(string input)
        {
            foreach (char c in input)
            {
                switch (c)
                {
                    case 'M':
                        Handler.HandleM();
                        break;
                    case 'L':
                        Handler.HandleL();
                        break;
                    case 'R':
                        Handler.HandleR();
                        break;
                    default:
                        throw new UnparseableCharException(c);
                }
            }
        }
    }

    public class UnparseableCharException : Exception
    {
        public UnparseableCharException(char c) : base(" : " + c) { }
    }
}
