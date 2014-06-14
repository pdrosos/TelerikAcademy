using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        //Task 8-9
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = new char[,] { { 'U' } };
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "unpassBlock" || otherCollisionGroupString == "indestrBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            
                if (collisionData.hitObjectsCollisionGroupStrings[0] == "indestrBlock" ||
                    collisionData.hitObjectsCollisionGroupStrings[0] == "racket" || 
                    collisionData.hitObjectsCollisionGroupStrings[0] == "unpassBlock")
                {
                    if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                    {
                        this.Speed.Row *= -1;
                    }
                    if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                    {
                        this.Speed.Col *= -1;
                    }
                }
            
        }
    }
}
