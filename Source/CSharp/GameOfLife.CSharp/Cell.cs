namespace GameOfLife.CSharp
{
    using System.Globalization;

    /// <summary>
    /// One coordinate on the board
    /// </summary>
    public class Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X-coordinate of this cell
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y-coordinate of this cell
        /// </summary>
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "[{0}, {1}]", X, Y);
        }

        protected bool Equals(Cell other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Cell) obj);
        }
    }
}
