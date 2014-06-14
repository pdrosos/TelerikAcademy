using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mobile
{
    public class GSM
    {
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        static public GSM iPhone4S = new GSM("iPhone4S", "Apple");
        

        private Battery battery = new Battery(null, 0, 0, BatteryType.NiCd);
        private Display display = new Display(1, 1);

        


        public GSM(string model, string manufacturer, int price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
            
        }

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, 0, null, null, null)
        { 
        
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (value.Length <= 1)
                {
                    throw new ArgumentOutOfRangeException("The model of the phone must be at least 2 characters long");
                }
                else
                {
                    value = this.model;
                }
                
                ;
            }





        }
        public string Manufacturer
        { get { return manufacturer;}
            set 
            {
                if (value.Length <= 1)
                {
                    throw new ArgumentOutOfRangeException("The manufacturer of the phone must be at least 2 characters long");
                }
                else
                {
                    value = this.manufacturer;
                }
                ;}
        }

        public decimal Price
        {
            get { return price;}
            set {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException("The price of the phone must not be 0");
                }
                else
                {
                    value = this.price;
                }
                ;}
        }
        public string Owner
        { get {return owner ;}
            set {
                if (value.Length <=1)
                {
                    throw new ArgumentOutOfRangeException("The owner's name must be at least 2 characters long");
                }
                else
                {
                    value = this.owner;
                }
                ;}
        }
        public static GSM IPhone4S 
        { get
            {return iPhone4S;} 
        }
        public List<Call> callHistory = new List<Call>();

        public override string ToString()
        {
            return string.Format("Model - {0},Manufacturer - {1},Price - {2},Battery - {3},Display - {4}",this.model,this.manufacturer,this.price,this.battery,this.display);
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void DeleteCalls(int callPosition)
        {
            this.callHistory.RemoveAt(callPosition);
        }

        public void clearCalls()
        {
            this.callHistory.Clear();
        }

        public decimal calcCost(decimal pricePerMinute)
        {
            decimal totalTime = 0;
            for (int i = 0; i < callHistory.Count; i++)
            {
                totalTime += callHistory[i].Duration;
            }
            decimal totalCost = pricePerMinute * totalTime;
            return totalCost;
        }

        public void showBill(decimal totalCost)
        { 
        Console.WriteLine("Your bill is {0}",totalCost);
        }

        public void showHistory(List<Call> callHistory)
        {
            for (int i = 0; i < callHistory.Count; i++)
            {
                Console.Write(this.callHistory[i].DateOfCall + " " + this.callHistory[i].DialedNumber + " " + this.callHistory[i].Duration + "seconds");
                Console.WriteLine();
            }
        }
    }
}