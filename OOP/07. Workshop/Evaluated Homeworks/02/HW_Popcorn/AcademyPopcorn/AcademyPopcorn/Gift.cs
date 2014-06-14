using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task - 11
    class Gift : MovingObject
    {
        public new const string CollisionGroupString = "gift";
        public ConsoleColor Color;

        public Gift(MatrixCoords topleft)
            : base(topleft, new char[,] { { 'g' } }, new MatrixCoords(+1, 0))
        {
            this.Color = ConsoleColor.Red;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

    }
}
