using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 12
    class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'G' } };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> list = new List<GameObject>();
            if (IsDestroyed)
            {
                MovingObject gift01 = new Gift(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col));
                list.Add(gift01);
            }
            return list;
        }

    }
}
