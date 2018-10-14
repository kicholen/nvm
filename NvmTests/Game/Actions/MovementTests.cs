using NSubstitute;
using NUnit.Framework;
using Nvm.Game.Data;
using Nvm.Game.Policy;

namespace Nvm.Game.Actions.Tests
{
    [TestFixture]
    public class MovementTests
    {
        Player player;
        IMovePolicy policy;
        IMovement movement;

        [SetUp]
        public void Setup()
        {
            player = new Player();
            policy = Substitute.For<IMovePolicy>();
            movement = new Movement(player, policy);
        }

        [TestCase(Direction.E, 1, 1)]
        [TestCase(Direction.N, 2, 4)]
        [TestCase(Direction.S, 3, 4)]
        [TestCase(Direction.W, 12, 23)]
        public void ExecuteDoNotChangeWhenPolicyFail(Direction direction, int x, int y)
        {
            SetupPlayer(direction, x, y);
            policy.Check(Arg.Any<int>(), Arg.Any<int>()).Returns(false);

            movement.Execute();

            policy.Received(1).Check(Arg.Any<int>(), Arg.Any<int>());
            AssertPosition(x, y);
        }

        [TestCase(Direction.E, 1, 1, 2, 1)]
        [TestCase(Direction.N, 2, 4, 2, 5)]
        [TestCase(Direction.S, 3, 4, 3, 3)]
        [TestCase(Direction.W, 12, 23, 11, 23)]
        [TestCase(Direction.W, -10, 0, -11, 0)]
        [TestCase(Direction.S, -1, 0, -1, -1)]
        public void Execute(Direction direction, int x, int y, int newX, int newY)
        {
            SetupPlayer(direction, x, y);
            policy.Check(newX, newY).Returns(true);

            movement.Execute();

            policy.Received(1).Check(newX, newY);
            AssertPosition(newX, newY);
        }

        void SetupPlayer(Direction direction, int x, int y)
        {
            player.Direction = direction;
            player.Position = new Point(x, y);
        }

        void AssertPosition(int x, int y)
        {
            Assert.AreEqual(x, player.Position.X);
            Assert.AreEqual(y, player.Position.Y);
        }
    }
}