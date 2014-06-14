using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 10
    class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'E' } };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true; // used as a key in ProduceObjects method
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> list = new List<GameObject>();
            if (IsDestroyed)
            {
                MovingObject debris01 = new Debris(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col + 1));
                list.Add(debris01);
                MovingObject debris02 = new Debris(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col));
                list.Add(debris02);
                MovingObject debris03 = new Debris(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col - 1));
                list.Add(debris03);
                MovingObject debris04 = new Debris(new MatrixCoords(this.topLeft.Row, this.topLeft.Col - 1));
                list.Add(debris04);
                MovingObject debris05 = new Debris(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + 1));
                list.Add(debris05);
                MovingObject debris06 = new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col + 1));
                list.Add(debris06);
                MovingObject debris07 = new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col));
                list.Add(debris07);
                MovingObject debris08 = new Debris(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col - 1));
                list.Add(debris08);
            }
            return list;
        }
    }
}
