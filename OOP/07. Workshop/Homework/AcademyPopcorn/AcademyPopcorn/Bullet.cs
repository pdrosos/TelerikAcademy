namespace AcademyPopcorn
{
    /// <summary>
    /// Task 13 - Bullet
    /// </summary>
    public class Bullet : MovingObject
    {
        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '^' } }, new MatrixCoords(-1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == "indestructibleBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
