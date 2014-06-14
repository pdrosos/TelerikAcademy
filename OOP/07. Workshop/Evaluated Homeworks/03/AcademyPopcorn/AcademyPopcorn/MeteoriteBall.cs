using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        private char[,] trailObjectBody = new char[,] { { '+' } };
        private int trailLifetime;

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed, int trailLifetime)
            : base(topLeft, speed)
        {
            this.trailLifetime = trailLifetime;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> tail = new List<TrailObject>();

            TrailObject trailObject = new TrailObject(this.TopLeft, this.trailLifetime);
            tail.Add(trailObject);

            return tail;
        }
    }
}
