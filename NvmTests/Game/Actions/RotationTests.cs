using NUnit.Framework;
using Nvm.Game.Data;

namespace Nvm.Game.Actions.Tests
{
    [TestFixture]
    public class RotationTests
    {
        Player player;
        Rotation rotation;

        [SetUp]
        public void Setup()
        {
            player = new Player();
            rotation = new Rotation(player);
        }

        [TestCase(Direction.N, Direction.W)]
        [TestCase(Direction.W, Direction.S)]
        [TestCase(Direction.S, Direction.E)]
        [TestCase(Direction.E, Direction.N)]
        public void ExecuteLeft(Direction before, Direction expected)
        {
            player.Direction = before;
            rotation.Execute(Turn.Left);
            Assert.AreEqual(expected, player.Direction);
        }

        [TestCase(Direction.N, Direction.E)]
        [TestCase(Direction.E, Direction.S)]
        [TestCase(Direction.S, Direction.W)]
        [TestCase(Direction.W, Direction.N)]
        public void ExecuteRight(Direction before, Direction expected)
        {
            player.Direction = before;
            rotation.Execute(Turn.Right);
            Assert.AreEqual(expected, player.Direction);
        }
    }
}