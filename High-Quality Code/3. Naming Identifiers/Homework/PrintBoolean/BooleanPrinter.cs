namespace PrintBoolean
{
    using System;

    public class BooleanPrinter
    {
        public void Print(bool boolean)
        {
            string booleanString = boolean.ToString();

            Console.WriteLine(booleanString);
        }
    }
}
