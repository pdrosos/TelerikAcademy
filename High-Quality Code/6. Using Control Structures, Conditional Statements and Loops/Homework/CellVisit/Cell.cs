namespace CellVisit
{
    public class Cell
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool Empty { get; set; }

        public bool IsEmpty()
        {
            return this.Empty;
        }
    }
}
