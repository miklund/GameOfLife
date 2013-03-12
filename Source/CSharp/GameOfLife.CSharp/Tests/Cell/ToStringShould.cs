using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameOfLife.CSharp.Tests.Cell
{
    using GameOfLife.CSharp;

    public class ToStringShould
    {
        [Test]
        public void CreateStringFromCoordinates()
        {
            const int X = 3;
            const int Y = 5;

            /* Setup */
            var cell = new Cell(X, Y);

            /* Test */
            var s = cell.ToString();

            /* Assert */
            Assert.That(s, Is.StringContaining(X.ToString()));
            Assert.That(s, Is.StringContaining(Y.ToString()));
        }
    }
}
