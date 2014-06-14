namespace MobilePhones.Library.Hardware
{
    using System;
    using System.Text;

    public class Battery
    {
        public enum BatteryTypes
        {
            LiIon, NiMH, NiCd
        };

        private BatteryTypes? batteryType;
        private string model;
        private float? hoursIdle;
        private float? hoursTalk;

        public Battery() : this(null, null, null, null)
        {
        }

        public Battery(BatteryTypes? batteryType, string model, float? hoursIdle, float? hoursTalk)
        {
            this.BatteryType = batteryType;
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public BatteryTypes? BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                switch (value)
                {
                    case null:
                    case BatteryTypes.LiIon:
                    case BatteryTypes.NiCd:
                    case BatteryTypes.NiMH:
                        this.batteryType = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid battery type");
                }
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Model can not be empty");
                }

                this.model = value;
            }
        }

        public float? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentException("Idle hours can not be less than zero");
                }

                this.hoursIdle = value;
            }
        }

        public float? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentException("Talk hours can not be less than zero");
                }

                this.hoursTalk = value;
            }
        }

        public override string ToString()
        {
            StringBuilder batteryInfo = new StringBuilder();

            batteryInfo.Append("Battery type: ").Append(this.BatteryType).AppendLine();
            batteryInfo.Append("Model: ").Append(this.Model).AppendLine();
            batteryInfo.Append("Hours idle: ").Append(this.HoursIdle).AppendLine();
            batteryInfo.Append("Hours talk: ").Append(this.HoursTalk);

            return batteryInfo.ToString();
        }
    }
}
