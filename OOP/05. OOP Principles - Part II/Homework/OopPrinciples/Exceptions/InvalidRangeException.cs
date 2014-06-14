namespace Exceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        protected T variable;
        protected T minValue;
        protected T maxValue;

        public InvalidRangeException(T variable, T minValue, T maxValue)
            : base()
        {
            this.variable = variable;
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override string Message
        {
            get
            {
                return string.Format("{0} is out of range. Valid range is between {1} and {2}", variable, minValue, maxValue);
            }
        }
    }
}
