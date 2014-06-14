namespace Points3D
{
    using System.Text;

    public struct Point3D
    {
        private float x;
        private float y;
        private float z;

        private static readonly Point3D center = new Point3D(0, 0, 0);

        public Point3D(float x, float y, float z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public float X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public float Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public float Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }

        public static Point3D Center
        {
            get
            {
                return center;
            }
        }

        public override string ToString()
        {
            StringBuilder pointInfo = new StringBuilder();

            pointInfo.Append("X = ").Append(this.X);
            pointInfo.Append(", Y = ").Append(this.Y);
            pointInfo.Append(", Z = ").Append(this.Z);

            return pointInfo.ToString();
        }
    }
}
