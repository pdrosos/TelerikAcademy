using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        public new const string CollisionGroupString = "trail";

        int lifetime;

        public TrailObject(MatrixCoords topLeft, int lifetime)
            : base(topLeft, new char[,] { { '*' } })
        {
            this.lifetime = lifetime;
        }

        public override void Update()
        {
            if (lifetime > 0)
            {
                lifetime--;
            }
            else
            {
                this.IsDestroyed = true;
            }
        }
    }
}
