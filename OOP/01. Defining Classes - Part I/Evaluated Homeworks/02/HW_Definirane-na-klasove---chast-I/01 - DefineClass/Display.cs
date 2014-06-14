using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    public class Display
    {
        private int displaySize;
        private int numberOfColors;

        public Display(int displaySize = 0, int numberOfColors = 0)
        {
            this.displaySize = displaySize;
            this.numberOfColors = numberOfColors;
        }

        public int DisplaySize 
        {
            get { return displaySize;}
            set { 
                if (value <= 0) 
                    {
                        throw new ArgumentOutOfRangeException("The display size must be a positive number");
                    }
                else
                    {
                value = this.displaySize;
                    }
                ;} 
        }
        public int NumberOfColors
        {
            get { return numberOfColors; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The number of the colors must be a positive number");
                }
                else 
                { value = this.numberOfColors; }
                ;
            } 
        }
    }
}
