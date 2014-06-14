using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Debris : MovingObject
    {
        //Task 10 - results of explosions
        public int LifeTime { get; protected set; }
        public new const string CollisionGroupString = "debris";

        public Debris(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { 'D' } }, new MatrixCoords(0, 0))
        {
            this.LifeTime = 3;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "unpassBlock" || otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return Debris.CollisionGroupString;
        }

        public override void Update()
        {
            this.LifeTime--;
            if (this.LifeTime == 0)
            {
                this.IsDestroyed = true;
            }

        }

    }

}
