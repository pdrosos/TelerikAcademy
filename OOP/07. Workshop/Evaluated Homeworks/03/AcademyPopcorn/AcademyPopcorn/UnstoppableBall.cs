using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains(IndestructibleBlock.CollisionGroupString) ||
                collisionData.hitObjectsCollisionGroupStrings.Contains(Racket.CollisionGroupString))
            {
                base.RespondToCollision(collisionData);
            }
        }
    }
}
