using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    public enum BatteryType
    {
        LiIon, NiMH, NiCd
    }

    public class Battery
    {
        private BatteryType batteryType;
        private uint hoursIdle;
        private uint hoursTalk;
        private string model;

        
        public Battery(string model = null, uint hoursIdle = 5, uint hoursTalk = 3, BatteryType batteryType = BatteryType.LiIon)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.batteryType = batteryType;
        }

        public BatteryType BatteryType
        {
            get { return batteryType; }
            set {
                if (!Enum.IsDefined(typeof(BatteryType),value))
                {
                    throw new Exception("Unknown battery type");
                }
                else
                {
                    value = this.batteryType;
                }
            }
        }

         
        public uint HoursTalk 
        {
            get { return hoursTalk; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("The value must be a positive number");
                }
                else
                {
                    value = this.hoursTalk;
                }
            } 
        
        }

        public uint HoursIdle 
        { 
          get {return hoursIdle;}
          set
          {
              if (value < 0)
              {
                  throw new Exception("The value must be a positive number");
              }
              else
              {
                  value = this.hoursIdle;
              }
          }
        }

        public string Model
        { get {return model ;} 
          set
          {
              if (value.Length < 4)
              {
                  throw new Exception("All model names are at least 4 characters long.");
              }
              else
              {
                  value = this.model;
              }
          } 
        }
        

    }



}