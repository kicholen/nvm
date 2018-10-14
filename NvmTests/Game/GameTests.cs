using NUnit.Framework;

namespace Nvm.Game.Tests
{
    [TestFixture]
    public class GameTests
    {
        Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void Creation()
        {
            Assert.IsNotNull(game.Handler);
            Assert.IsNotNull(game.Player);
            Assert.AreEqual(Game.StartDirection, game.Player.Direction);
            Assert.AreEqual(Game.StartX, game.Player.Position.X);
            Assert.AreEqual(Game.StartY, game.Player.Position.Y);
            Assert.IsNotNull(game.Parser);
        }

        [TestCase("MRMLMRM", "2 2 E")]
        [TestCase("RMMMLMM", "3 2 N")]
        [TestCase("MMMMM", "0 4 N")]
        [TestCase("RRRMMRRMMRMLLMMMMMMLLMMRMMLRRRRRRRRMM", "0 0 S")]
        [TestCase("RRRMMRRMMRMLLMMMMMMLLMMRMMLRRRRRRRRM", "0 1 S")]
        public void OnTaskInput(string input, string output)
        {
            game.OnInput(input);
            Assert.AreEqual(output, game.Player.ToString());
        }
    }
}