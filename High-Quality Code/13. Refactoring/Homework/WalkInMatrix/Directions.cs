namespace WalkInMatrix
{
    public class Directions
    {
        public Directions()
        {
            this.X = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
            this.Y = new int[] { 1, 0, -1, -1, -1, 0, 1, 1 };
        }

        public int[] X { get; private set; }

        public int[] Y { get; private set; }
    }
}
