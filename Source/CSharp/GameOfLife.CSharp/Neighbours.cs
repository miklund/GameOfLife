namespace GameOfLife.CSharp
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Neighbours
    {
        /// <summary>
        /// Get all neighbouring cells of cell
        /// </summary>
        public static IEnumerable<Cell> Of(Cell cell)
        {
            // iterate coordinates around cell
            for (var y = cell.Y - 1; y < cell.Y + 2; y++)
            for (var x = cell.X - 1; x < cell.X + 2; x++)
            {
                // skip cell itself
                if (x == cell.X && y == cell.Y)
                {
                    continue;
                }

                yield return new Cell(x, y);
            }
        }

        /// <summary>
        /// Intersection between cells and board (is live cells)
        /// </summary>
        public static IEnumerable<Cell> FilterLive(this IEnumerable<Cell> cells, IEnumerable<Cell> board)
        {
            return cells.Where(board.Contains);
        }

        /// <summary>
        /// Difference between cells and board (is dead cells)
        /// </summary>
        public static IEnumerable<Cell> FilterDead(this IEnumerable<Cell> cells, IEnumerable<Cell> board)
        {
            return cells.Where(cell => !board.Contains(cell));
        }
    }
}
