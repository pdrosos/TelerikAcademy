using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    //Task 6
    public class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = new char[,] { { 'M' } };
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            TrailObject trail01 = new TrailObject(this.topLeft, 3);
            List<GameObject> list = new List<GameObject>();
            list.Add(trail01);
            return list;
        }

    }
}
