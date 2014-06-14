using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 8-9
    public class UnpassableBlock : IndestructibleBlock
    {
        public new const string CollisionGroupString = "unpassBlock";
        public const char Symbol1 = '@';

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol1;
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings[0] == "debris") //Only explosion and its result could destroy unpassable blocks
            {
                this.IsDestroyed = true;
            }

        }
    }
}
