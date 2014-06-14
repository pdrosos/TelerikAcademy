using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    public class Call
    {
        private DateTime dateOfCall = new DateTime();
        private string dialedNumber = null;
        private int duration = 0;

        public Call(DateTime dateOfCall, string dialedNumber, int duration)
        {
            this.dateOfCall = dateOfCall;
            this.dialedNumber = dialedNumber;
            this.duration = duration;

        }

        public DateTime DateOfCall
        {
            get { return dateOfCall;}
            set { value = this.dateOfCall; }
        }

        public string DialedNumber 
        { 
            get {return dialedNumber;} 
            set{value = this.dialedNumber;} 
        }

        public int Duration 
        {
            get { return duration;}
            set { value = this.duration;}
        }
    }
}
