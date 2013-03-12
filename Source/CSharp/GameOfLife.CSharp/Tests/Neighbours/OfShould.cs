namespace GameOfLife.CSharp.Tests.Neighbours
{
    using NUnit.Framework;
    using GameOfLife.CSharp;

    public class OfShould
    {
        [Test]
        public void CalculateAllNeighboursOfCell()
        {
            /* Setup */
            var cell = new Cell(0, 0);

            /* Test */
            var result = Neighbours.Of(cell);

            /* Assert */
            Assert.That(result, Is.EqualTo(new[]
                {
                    new Cell(-1, -1), new Cell(0, -1), new Cell(1, -1),
                    new Cell(-1, 0), new Cell(1, 0),
                    new Cell(-1, 1), new Cell(0, 1), new Cell(1, 1)
                }));
        }

        [Test]
        public void NotReturnTheCellAsNeighbour()
        {
            /* Setup */
            var cell = new Cell(0, 0);

            /* Test */
            var result = Neighbours.Of(cell);

            /* Assert */
            Assert.That(result, Is.Not.Contains(cell));
        }
    }
}
