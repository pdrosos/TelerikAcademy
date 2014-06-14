using System;

class Call
{
    public DateTime DateTime { get; set; }
    public string DialedPhoneNumber { get; set; }
    public int Duration { get; set; }

    public Call(DateTime dateTime, string dialedPhoneNumber, int duration)
    {
        this.DateTime = dateTime;
        this.DialedPhoneNumber = dialedPhoneNumber;
        this.Duration = duration;
    }

    public Call(string dialedPhoneNumber, int duration)
        : this(new DateTime(), dialedPhoneNumber, duration)
    {
    }

    public Call()
        : this(new DateTime(), null, 0)
    {
    }

    public override string ToString()
    {
        if (this.DateTime == DateTime.MinValue)
        {
            return string.Format(
            "Dialed phone number: {0}, Duration: {1}", 
            this.DialedPhoneNumber, this.Duration);
        }
        return string.Format(
            "Date-Time: {0}, Dialed phone number: {1}, Duration: {2}",
            this.DateTime, this.DialedPhoneNumber, this.Duration);
    }
}