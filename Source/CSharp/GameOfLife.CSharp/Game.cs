namespace GameOfLife.CSharp
{
    using System.Collections.Generic;
    using System.Linq;
    
    /// <summary>
    /// Play's game of life
    /// </summary>
    public class Game
    {
        private readonly List<Cell> board; 

        public Game()
            : this(new List<Cell>())
        {   
        }

        /// <param name="board">Initial state</param>
        public Game(IEnumerable<Cell> board)
        {
            this.board = new List<Cell>(board);
        }

        public IEnumerable<Cell> Board
        {
            get { return board; }
        }

        public void Next()
        {
            lock (board)
            {
                var nextBoard = new List<Cell>(Board);
            
                foreach (var cell in nextBoard)
                {
                    var liveNeighboursCount = Neighbours.Of(cell).FilterLive(nextBoard).Count();

                    // 1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
                    if (liveNeighboursCount < 2)
                    {
                        this.board.Remove(cell);
                    }

                    // 2. Any live cell with two or three live neighbours lives on to the next generation.
                    // essentially do nothing

                    // 3. Any live cell with more than three live neighbours dies, as if by overcrowding.
                    if (liveNeighboursCount > 3)
                    {
                        this.board.Remove(cell);
                    }
                }

                // 4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                var newCells = nextBoard.SelectMany(
                    cell => Neighbours.Of(cell).FilterDead(nextBoard)
                        .Where(dead => Neighbours.Of(dead).FilterLive(nextBoard).Count() == 3));

                foreach (var cell in newCells.Distinct())
                {
                    board.Add(cell);
                }
            }
        }
    }
}
