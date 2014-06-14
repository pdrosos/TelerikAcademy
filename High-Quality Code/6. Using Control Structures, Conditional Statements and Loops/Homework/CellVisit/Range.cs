namespace CellVisit
{
    public class Range
    {
        public Range(int minX, int minY, int maxX, int maxY)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
        }

        public int MinX { get; set; }

        public int MaxX { get; set; }

        public int MinY { get; set; }

        public int MaxY { get; set; }

        public bool Contains(Cell cell)
        {
            if (cell.X >= this.MinX && cell.X <= this.MaxX && cell.Y >= this.MinY && cell.Y <= this.MaxY)
            {
                return true;
            }

            return false;
        }
    }
}
