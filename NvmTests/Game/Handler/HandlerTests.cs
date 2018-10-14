using NSubstitute;
using NUnit.Framework;
using Nvm.Game.Actions;

namespace Nvm.Game.Handler.Tests
{
    [TestFixture]
    public class HandlerTests
    {
        IMovement movement;
        IRotation rotation;
        Handler handler;

        [SetUp]
        public void Setup()
        {
            movement = Substitute.For<IMovement>();
            rotation = Substitute.For<IRotation>();

            handler = new Handler(movement, rotation);
        }

        [Test]
        public void HandleM()
        {
            handler.HandleM();

            movement.Received().Execute();
            rotation.DidNotReceiveWithAnyArgs().Execute(Arg.Any<Turn>());
        }

        [Test]
        public void HandleL()
        {
            handler.HandleL();

            rotation.Received().Execute(Turn.Left);
            movement.DidNotReceive().Execute();
        }

        [Test]
        public void HandleR()
        {
            handler.HandleR();

            rotation.Received().Execute(Turn.Right);
            movement.DidNotReceive().Execute();
        }
    }
}