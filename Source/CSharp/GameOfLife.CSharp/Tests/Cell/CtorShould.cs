using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameOfLife.CSharp.Tests.Cell
{
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
