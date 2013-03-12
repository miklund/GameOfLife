using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameOfLife.CSharp.Tests.Neighbours
{
    using GameOfLife.CSharp;

    public class FilterDeadShould
    {
        [Test]
        public void ReturnDifferenceBetweenNeighouringCellsAndBoard()
        {
            /* Setup */
            var cell = new Cell(0, 0);
            var board = new[] { new Cell(-1, 0), cell, new Cell(1, 0) };

            /* Test */
            var result = Neighbours.Of(cell).FilterDead(board);

            /* Assert */
            Assert.That(result, Is.EqualTo(new[]
                {
                    new Cell(-1, -1), new Cell(0, -1), new Cell(1, -1),
                    new Cell(-1, 1), new Cell(0, 1), new Cell(1, 1),
                }));
        }
    }
}
