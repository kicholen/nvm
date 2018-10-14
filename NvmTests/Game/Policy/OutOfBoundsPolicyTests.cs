using NUnit.Framework;

namespace Nvm.Game.Actions.Mover.Policy.Tests
{
    [TestFixture]
    public class OutOfBoundsPolicyTests
    {

        [Test]
        public void IncorrectCreation([Values(-10, -1, 0)]int size)
        {
            Assert.Throws<IncorrectSizeException>(() => new OutOfBoundsPolicy(size));
        }

        [TestCase(0, 0, true)]
        [TestCase(1, 0, false)]
        [TestCase(0, 1, false)]
        [TestCase(-1, 0, false)]
        [TestCase(0, -1, false)]
        [TestCase(-1, -1, false)]
        [TestCase(1, 1, false)]
        public void CheckSmallest(int x, int y, bool isCorrect)
        {
            Assert.AreEqual(isCorrect, new OutOfBoundsPolicy(1).Check(x, y));
        }

        [TestCase(0, 0, true)]
        [TestCase(1, 1, true)]
        [TestCase(1, 0, true)]
        [TestCase(0, 1, true)]
        [TestCase(-1, 0, false)]
        [TestCase(0, -1, false)]
        public void CheckCornersOnSmallSized(int x, int y, bool isCorrect)
        {
            Assert.AreEqual(isCorrect, new OutOfBoundsPolicy(2).Check(x, y));
        }

        [TestCase(100, 99, 99, true)]
        [TestCase(100, 99, 100, false)]
        [TestCase(100, 100, 99, false)]
        [TestCase(10, 0, 0, true)]
        [TestCase(10, -1, -1, false)]
        [TestCase(10, 0, -1, false)]
        [TestCase(10, -1, 0, false)]
        [TestCase(20, 19, 0, true)]
        [TestCase(20, 20, 0, false)]
        [TestCase(30, 0, 29, true)]
        [TestCase(30, 0, 30, false)]
        [TestCase(5, 2, 3, true)]
        [TestCase(5, 1, 1, true)]
        public void CheckSpecialCases(int size, int x, int y, bool isCorrect)
        {
            Assert.AreEqual(isCorrect, new OutOfBoundsPolicy(size).Check(x, y));
        }
    }
}