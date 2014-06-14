namespace AcademyPopcorn
{
    /// <summary>
    /// Task 5 - Trail object
    /// </summary>
    public class TrailObject : GameObject
    {
        public int LifeTime { get; set; }

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifeTime) : base(topLeft, body)
        {
            this.LifeTime = lifeTime;
        }

        public override void Update()
        {
            LifeTime--;

            if (LifeTime <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
