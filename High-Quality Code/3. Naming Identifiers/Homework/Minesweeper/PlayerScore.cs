namespace Minesweeper
{
    public class PlayerScore
    {
        private string name;
        private int points;

        public PlayerScore()
        {
        }

        public PlayerScore(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }
    }
}
