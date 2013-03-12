namespace GameOfLife.CSharp.Tests.Cell
{
    using NUnit.Framework;
    using GameOfLife.CSharp;

    public class EqualsShould
    {
        [Test]
        public void ReturnTrueWhenCoordinatesAreEqual()
        {
            /* Setup */
            var cell1 = new Cell(1, 2);
            var cell2 = new Cell(1, 2);

            /* Test */
            var result = cell1.Equals(cell2);

            /* Assert */
            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnFalseWhenItemIsNull()
        {
            /* Setup */
            var cell = new Cell(1, 2);

            /* Test */
            var result = cell.Equals(null);

            /* Assert */
            Assert.That(result, Is.False);
        }

        [Test]
        public void ReturnTrueWhenItemIsSame()
        {
            /* Setup */
            var cell1 = new Cell(1, 2);
            var cell2 = cell1;

            /* Test */
            var result = cell1.Equals(cell2);

            /* Assert */
            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnFalseWhenItemIsOfOtherType()
        {
            /* Setup */
            var cell1 = new Cell(1, 2);
            var game = new Game();

            /* Test */
            var result = cell1.Equals(game);

            /* Assert */
            Assert.That(result, Is.False);
        }
    }
}
