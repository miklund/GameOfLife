namespace GameOfLife.CSharp.Tests.Neighbours
{
    using NUnit.Framework;
    using GameOfLife.CSharp;

    public class FilterLiveShould
    {
        [Test]
        public void ReturnIntersectionOfNeighboursAndBoard()
        {
            /* Setup */
            var cell = new Cell(0, 0);
            var board = new[] { new Cell(-1, 0), cell, new Cell(1, 0) };

            /* Test */
            var result = Neighbours.Of(cell).FilterLive(board);

            /* Assert */
            Assert.That(result, Is.EqualTo(new[] { new Cell(-1, 0), new Cell(1, 0) }));
        }
    }
}
