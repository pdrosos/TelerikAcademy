using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<Splinter> splinters = new List<Splinter>();

                splinters.Add(new Splinter(this.TopLeft, new MatrixCoords(-1, -1)));
                splinters.Add(new Splinter(this.TopLeft, new MatrixCoords(-1, 0)));
                splinters.Add(new Splinter(this.TopLeft, new MatrixCoords(-1, 1)));
                splinters.Add(new Splinter(this.TopLeft, new MatrixCoords(0, -1)));
                splinters.Add(new Splinter(this.TopLeft, new MatrixCoords(0, 1)));
                splinters.Add(new Splinter(this.TopLeft, new MatrixCoords(1, -1)));
                splinters.Add(new Splinter(this.TopLeft, new MatrixCoords(1, 0)));
                splinters.Add(new Splinter(this.TopLeft, new MatrixCoords(1, 1)));

                return splinters;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
