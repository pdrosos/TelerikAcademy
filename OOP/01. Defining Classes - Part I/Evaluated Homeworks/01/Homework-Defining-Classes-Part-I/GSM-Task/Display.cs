using System;

class Display
{
    private int size;
    private int numberOfColors;


    public Display(int size, int numberOfColors)
    {
        this.Size = size;
        this.NumberOfColors = numberOfColors;
    }

    public Display()
        : this(0, 0)
    {
    }

    public int Size
    {
        get { return this.size; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Size cannot be negative");
            }
            this.size = value;
        }
    }

    public int NumberOfColors
    {
        get { return this.numberOfColors; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The number of colors cannot be negative");
            }
            this.numberOfColors = value;
        }
    }

    public override string ToString()
    {
        return string.Format(
            "Size: {0}, Number of Colors: {1}",
            this.size, this.numberOfColors);
    }
}