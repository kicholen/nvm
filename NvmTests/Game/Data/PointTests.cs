using NUnit.Framework;

namespace Nvm.Game.Data.Tests
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        [Sequential]
        public void Creation([Values(-100, 0, 1, 23)]int x, [Values(0, -23, 43, 543)]int y)
        {
            Point point = new Point(x, y);

            Assert.AreEqual(x, point.X);
            Assert.AreEqual(y, point.Y);
        }

        [TestCase(0, 1, 2, 3)]
        [TestCase(-10, 20, 32, 43)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(0, 0, -1, -2)]
        [TestCase(2, 3, -1, 3)]
        public void OperatorPlus(int firstX, int firstY, int secondX, int secondY)
        {
            Point expected = new Point(firstX, firstY);
            Point result = new Point(secondX, secondY);
            Assert.AreEqual(firstX + secondX, (expected + result).X);
            Assert.AreEqual(firstY + secondY, (expected + result).Y);
        }

        [TestCase(0, 1, "0 1")]
        [TestCase(2, 3, "2 3")]
        [TestCase(-10, 32, "-10 32")]
        [TestCase(4923, 0, "4923 0")]
        public void CheckToString(int x, int y, string expected)
        {
            Assert.AreEqual(expected, new Point(x, y).ToString());
        }
    }
}