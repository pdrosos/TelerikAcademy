using System;

class InvalidRangeException<T> : Exception
{
    public T Start { get; private set; }
    public T End { get; private set; }

    public InvalidRangeException(string message, T start, T end)
        : base(message)
    {
        this.Start = start;
        this.End = end;
    }

    public InvalidRangeException(string message, T start, T end, Exception innerException)
        : base(message, innerException)
    {
        this.Start = start;
        this.End = end;
    }
}
