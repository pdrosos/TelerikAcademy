namespace CellVisit
{
    using System.Collections.Generic;

    public class Maze
    {
        public Cell CurrentCell { get; set; }

        public IList<Cell> VisitedCells { get; set; }

        public IList<Cell> NeighbourCells { get; set; }

        public Range Range { get; set; }

        public bool IsCurrentCellInRange()
        {
            return Range.Contains(this.CurrentCell);
        }

        public bool IsCurrentCellVisited()
        {
            return this.VisitedCells.Contains(this.CurrentCell);
        }

        public bool AreNeighbourCellsEmpty()
        {
            foreach (Cell cell in this.NeighbourCells)
            {
                if (cell.IsEmpty() == false)
                {
                    return false;
                }
            }

            return true;
        }

        public bool ShouldVisitCurrentCell()
        {
            return this.IsCurrentCellInRange() && this.CurrentCell.IsEmpty() &&
                this.AreNeighbourCellsEmpty() && !this.IsCurrentCellVisited();
        }
    }
}
