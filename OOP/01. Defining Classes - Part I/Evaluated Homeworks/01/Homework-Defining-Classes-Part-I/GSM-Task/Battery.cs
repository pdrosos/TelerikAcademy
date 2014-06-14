using System;

public enum BatteryType
{
    LiIon, NiMH, NiCd
}

class Battery
{
    private string batteryModel;
    private int hoursIdle;
    private int hoursTalk;
    private BatteryType type;

    public Battery(string model, int hoursIdle, int hoursTalk, BatteryType type)
    {
        this.BatteryModel = model;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
        this.Type = type;
    }

    public Battery()
        : this(null, 0, 0, 0)
    {
    }

    public Battery(string model)
        : this(model, 0, 0, 0)
    {
    }

    public Battery(int hoursIdle, int hoursTalk)
        : this(null, hoursIdle, hoursTalk, 0)
    {
    }

    public string BatteryModel
    {
        get { return this.batteryModel; }
        set { this.batteryModel = value; }
    }

    public int HoursIdle
    {
        get { return this.hoursIdle; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Idle hours cannot be negative");
            }
            this.hoursIdle = value;
        }
    }

    public int HoursTalk
    {
        get { return this.hoursTalk; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Talk hours cannot be negative");
            }
            this.hoursTalk = value;
        }
    }

    public BatteryType Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    public override string ToString()
    {
        return string.Format(
            "Model: {0}, Hours idle: {1}, Hours talk: {2}, Battery type: {3}",
            this.batteryModel, this.hoursIdle, this.hoursTalk,
            this.type);
    }
}