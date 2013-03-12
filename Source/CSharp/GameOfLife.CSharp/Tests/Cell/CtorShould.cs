namespace GameOfLife.CSharp.Tests.Cell
{
    using NUnit.Framework;
    using GameOfLife.CSharp;

    public class CtorShould
    {
        [Test]
        public void SetCoordinatesAsProperties()
        {
            const int X = 1;
            const int Y = 2;

            /* Test */
            var cell = new Cell(X, Y);

            /* Assert */
            Assert.That(cell.X, Is.EqualTo(X));
            Assert.That(cell.Y, Is.EqualTo(Y));
        }
    }
}
