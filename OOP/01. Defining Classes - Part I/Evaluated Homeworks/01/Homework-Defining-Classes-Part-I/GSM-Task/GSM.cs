using System;

class GSM
{
    private string model;
    private string manifacturer;
    private decimal price;
    private string owner;
    private Display gsmDisplay;
    private Battery gsmBattery;
    private static GSM iPhone4S = new GSM("IPhone", "Apple");

    public GSM(
        string model, string manifacturer,
        decimal price, string owner,
        Display gsmDisplay, Battery gsmBattery)
    {
        this.Model = model;
        this.Manifacturer = manifacturer;
        this.Price = price;
        this.Owner = owner;
        this.GsmDisplay = gsmDisplay;
        this.GsmBattery = gsmBattery;
    }

    public GSM(string model, string manifacturer)
        : this(model, manifacturer, 0, null, null, null)
    {
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public string Manifacturer
    {
        get { return this.manifacturer; }
        set { this.manifacturer = value; }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Price cannot be negative");
            }
            this.price = value;
        }
    }

    public string Owner
    {
        get { return this.owner; }
        set { this.owner = value; }
    }

    public Display GsmDisplay
    {
        get { return this.gsmDisplay; }
        set { this.gsmDisplay = value; }
    }

    public Battery GsmBattery
    {
        get { return this.gsmBattery; }
        set { this.gsmBattery = value; }
    }

    public static GSM IPhone4S
    {
        get
        {
            return iPhone4S;
        }
    }

    public override string ToString()
    {
        return string.Format(
            "Model: {0}\nManifacturer: {1}\nPrice: ${2}\nOwner: {3}\nBattery: {4}\nDisplay: {5}",
            this.model, this.manifacturer, this.price,
            this.owner, this.gsmBattery, this.gsmDisplay);
    }
}