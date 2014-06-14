namespace MobilePhones.Library.Hardware
{
    using System;
    using System.Text;
    using MobilePhones.Library.Software;
    
    public class Gsm
    {
        private static readonly Gsm iPhone4S = new Gsm("iPhone 4S", "Apple", 1200, null, 
            new Battery(Battery.BatteryTypes.LiIon, null, null, null), 
            new Display(3.5f, null));

        private string model;
        private string manufacturer;
        private double? price;
        private string owner;

        private Battery battery;
        private Display display;

        private readonly CallsManager callsManager;

        public Gsm(string model, string manufacturer) : this(model, manufacturer, null, null, new Battery(), new Display())
        {
        }

        public Gsm(string model, string manufacturer, double? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;

            this.callsManager = new CallsManager();
        }

        public static Gsm IPhone4S
        {
            get
            {
                return iPhone4S;
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

        public string Manufacturer
        {
            get 
            { 
                return manufacturer; 
            }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Manufacturer can not be empty");
                }

                manufacturer = value; 
            }
        }

        public double? Price
        {
            get 
            { 
                return this.price; 
            }
            set 
            {
                if (value != null && value <= 0)
                {
                    throw new ArgumentException("Price can not be equal to or less than zero");
                }

                this.price = value; 
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Owner can not be empty");
                }

                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public CallsManager CallsManager
        {
            get
            {
                return this.callsManager;
            }
        }

        public override string ToString()
        {
            StringBuilder gsmInfo = new StringBuilder();

            gsmInfo.Append("Model: ").Append(this.Model).AppendLine();
            gsmInfo.Append("Manufacturer: ").Append(this.Manufacturer).AppendLine();
            gsmInfo.Append("Price: ").Append(this.Price).AppendLine();
            gsmInfo.Append("Owner: ").Append(this.Owner).AppendLine();
            gsmInfo.Append("Battery: ").AppendLine().Append(this.Battery).AppendLine();
            gsmInfo.Append("Display: ").AppendLine().Append(this.Display);

            return gsmInfo.ToString();
        }
    }
}
