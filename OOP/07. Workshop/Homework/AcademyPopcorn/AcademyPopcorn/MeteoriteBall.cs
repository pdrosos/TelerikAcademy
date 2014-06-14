namespace AcademyPopcorn
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 6 - Meteorite ball
    /// </summary>
    public class MeteoriteBall : Ball
    {
        protected char trailSymbol = '*';
        protected int trailLifeTime = 3;

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed, int trailLifeTime)
            : base(topLeft, speed)
        {
            this.TrailLifeTime = trailLifeTime;
        }

        public char TrailSymbol
        {
            get
            {
                return this.trailSymbol;
            }
            set
            {
                this.trailSymbol = value;
            }
        }

        public int TrailLifeTime
        {
            get
            {
                return this.trailLifeTime;
            }
            set
            {
                this.trailLifeTime = value;
            }
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            produceObjects.Add(new TrailObject(base.topLeft, new char[,] { { this.trailSymbol } }, this.TrailLifeTime));

            return produceObjects;
        }
    }
}
