namespace areyesram
{
    internal class Cell
    {
        internal int X { get; set; }
        internal int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Cell operator +(Cell a, Cell b)
        {
            return new Cell(a.X + b.X, a.Y + b.Y);
        }
    }
}