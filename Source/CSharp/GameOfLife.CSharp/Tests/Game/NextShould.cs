using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameOfLife.CSharp.Tests.Game
{
    using GameOfLife.CSharp;

    public class NextShould
    {
        [Test]
        public void KillOffAnyLonelyCellsWithoutAnyNeighbours()
        {
            var board = new[] { new Cell(0, 0), new Cell(2, 2), new Cell(10, 5) };

            /* Setup */
            var game = new Game(board);

            /* Test */
            game.Next();

            /* Assert */
            Assert.That(game.Board, Is.Empty);
        }

        [Test]
        public void PreserveCellsWithTwoOrThreeNeighbours()
        {
            var board = new[] { new Cell(0, 0), new Cell(0, 1), new Cell(1, 0), new Cell(1, 1) };

            /* Setup */
            var game = new Game(board);

            /* Test */
            game.Next();

            /* Assert */
            Assert.That(game.Board, Is.EqualTo(board));
        }

        [Test]
        public void KillCellsWithFourOrMoreNeighbours()
        {
            // x formation, kill one in the middle
            var middleCell = new Cell(0, 0);
            var board = new[] { new Cell(-1, -1), new Cell(-1, 1), new Cell(1, -1), new Cell(1, 1), middleCell };

            /* Setup */
            var game = new Game(board);

            /* Test */
            game.Next();

            /* Assert */
            Assert.That(game.Board, Is.Not.Contains(middleCell));
        }

        [Test]
        public void GrowDeadCellWithThreeOrMoreLiveNeighbours()
        {
            // corners of 3x3 vector - grow cell in the middle
            var middleCell = new Cell(0, 0);
            var board = new[] { new Cell(-1, -1), new Cell(-1, 1), new Cell(1, -1), new Cell(1, 1) };

            /* Setup */
            var game = new Game(board);

            /* Test */
            game.Next();

            /* Assert */
            Assert.That(game.Board, Contains.Item(middleCell));
        }

        [Test]
        public void SupportBlinkerFirstStage()
        {
            // three cells in a row
            var board = new[] { new Cell(-1, 0), new Cell(0, 0), new Cell(1, 0) };

            /* Setup */
            var game = new Game(board);

            /* Test */
            game.Next();

            /* Assert */
            Assert.That(game.Board, Is.EqualTo(new[] { new Cell(0, 0), new Cell(0, -1), new Cell(0, 1) }));
        }

        [Test]
        public void SupportBeaconFirstStage()
        {
            // classic beacon
            var board = new[] { new Cell(0, -1), new Cell(0, 0), new Cell(1, 0), new Cell(2, -3), new Cell(3, -3), new Cell(3, -2) };

            /* Setup */
            var game = new Game(board);

            /* Test */
            game.Next();

            /* Assert */
            var expected = new[] { new Cell(0, -1), new Cell(0, 0), new Cell(1, 0), new Cell(2, -3), new Cell(3, -3), new Cell(3, -2), new Cell(1, -1), new Cell(2, -2),  };
            Assert.That(game.Board, Is.EqualTo(expected));
        }

        [Test]
        public void SupportBeaconSecondStage()
        {
            // classic beacon
            var board = new[] { new Cell(0, -1), new Cell(0, 0), new Cell(1, 0), new Cell(2, -3), new Cell(3, -3), new Cell(3, -2) };

            /* Setup */
            var game = new Game(board);

            /* Test */
            game.Next();
            game.Next();

            /* Assert */
            var expected = new[] { new Cell(0, -1), new Cell(0, 0), new Cell(1, 0), new Cell(2, -3), new Cell(3, -3), new Cell(3, -2) };
            Assert.That(game.Board, Is.EqualTo(expected));
        }
    }
}
