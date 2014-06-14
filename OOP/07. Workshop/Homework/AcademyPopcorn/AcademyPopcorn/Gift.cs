namespace AcademyPopcorn
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 11 - Gift
    /// </summary>
    public class Gift : MovingObject
    {
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '+' } }, new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        // Task 13 - Add shooting racket
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();

            if (this.IsDestroyed)
            {
                produceObjects.Add(new ShootingRacket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col), 6));
            }

            return produceObjects;
        }
    }
}
