using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 5
    class TrailObject : GameObject
    {
        public int LifeTime { get; set; }
        public new const string CollisionGroupString = "block";

        public TrailObject(MatrixCoords topLeft, int lifetime)
            : base(topLeft, new char[,]{{'T'}})
        {
            this.LifeTime = lifetime;
        }
       //
       // public override bool CanCollideWith(string otherCollisionGroupString)
       // {
       //     return otherCollisionGroupString == "ball";
       // }

       // public override void RespondToCollision(CollisionData collisionData)
       // {
       //     this.IsDestroyed = true;
       // }

       // public override string GetCollisionGroupString()
       // {
       //     return TrailObject.CollisionGroupString;
       // }

        public override void Update()
        {
            this.LifeTime--;
            if (this.LifeTime==0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
