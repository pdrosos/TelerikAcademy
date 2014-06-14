namespace MobilePhones.Library.Hardware
{
    using System;
    using System.Text;

    public class Display
    {
        private float? size;
        private uint? numberOfColors;

        public Display() : this(null, null)
        {
        }

        public Display(float? size, uint? numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }
        
        public float? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentException("Size can not be equal to or less than zero");
                }

                this.size = value;
            }
        }

        public uint? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentException("Number of colors can not be equal to or less than zero");
                }

                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder displayInfo = new StringBuilder();

            displayInfo.Append("Size in inches: ").Append(this.Size).AppendLine();
            displayInfo.Append("Number of colors: ").Append(this.NumberOfColors);

            return displayInfo.ToString();
        }
    }
}
