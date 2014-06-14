using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 13 - shot objects
    class Bullet : MovingObject
    {
        
        public Bullet(MatrixCoords topleft)
            : base(topleft, new char[,] { { '^' } }, new MatrixCoords(-1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == "indestrBlock"
                || otherCollisionGroupString == "unpassBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

    }
}
