using NSubstitute;
using NUnit.Framework;
using Nvm.Game.Handler;

namespace Nvm.Game.Parser.Tests
{
    [TestFixture]
    public class SyntaxParserTests
    {
        IHandler handler;
        SyntaxParser syntaxParser;

        [SetUp]
        public void Setup()
        {
            handler = Substitute.For<IHandler>();
            syntaxParser = new SyntaxParser(handler);
        }

        [Test]
        public void ParseSingleM([Values("M")]string value)
        {
            syntaxParser.Parse(value);

            handler.Received(1).HandleM();
        }

        [Test]
        public void ParseSingleL([Values("L")]string value)
        {
            syntaxParser.Parse(value);

            handler.Received(1).HandleL();
        }

        [Test]
        public void ParseSingleR([Values("R")]string value)
        {
            syntaxParser.Parse(value);

            handler.Received(1).HandleR();
        }

        [Test]
        public void ParseUnparseableChar([Values("ML1", "RMXM", "Z")]string value)
        {
            Assert.Throws<UnparseableCharException>(() => syntaxParser.Parse(value));
        }

        [TestCase("MLMMLLMM")]
        [TestCase("LRRRLMRLR")]
        [TestCase("LLRRMMLRM")]
        [TestCase("MMM")]
        [TestCase("LRM")]
        public void ParseMultiple(string value)
        {
            syntaxParser.Parse(value);

            Received.InOrder(() => {
                foreach (char c in value)
                {
                    if (c == 'M')
                        handler.HandleM();
                    else if (c == 'L')
                        handler.HandleL();
                    else if (c == 'R')
                        handler.HandleR();
                }
            });
        }
    }
}