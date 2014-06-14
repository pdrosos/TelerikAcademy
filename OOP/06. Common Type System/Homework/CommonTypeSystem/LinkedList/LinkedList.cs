namespace LinkedList
{
    using System;

    class LinkedList<T> : ICloneable
    {
        public T Value { get; set; }
        public LinkedList<T> NextNode { get; set; }

        public LinkedList(T value, LinkedList<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        object ICloneable.Clone()  // Implicit implementation
        {
            return this.Clone();
        }

        public LinkedList<T> Clone() // our method Clone()
        {
            // Copy the first element
            LinkedList<T> firstElement = new LinkedList<T>(this.Value);
            LinkedList<T> currentElement = firstElement;
            LinkedList<T> nextElement = this.NextNode;

            // Copy the rest of the elements
            while (nextElement != null)
            {
                currentElement.NextNode = new LinkedList<T>(nextElement.Value);
                nextElement = nextElement.NextNode;
                currentElement = currentElement.NextNode;
            }

            return firstElement;
        }
    }
}
