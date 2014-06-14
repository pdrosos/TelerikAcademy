namespace AcademyPopcorn
{
    /// <summary>
    /// Task 10 - Explosion piece
    /// </summary>
    public class ExplosionPiece : MovingObject
    {
        public ExplosionPiece(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed)
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void Update()
        {
            this.IsDestroyed = true;
        }
    }
}
