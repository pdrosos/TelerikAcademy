namespace GenericLists
{
    using System;

    /// <summary>
    /// Generic list of elements which can be ordered, sorted, compared
    /// </summary>
    /// <typeparam name="Element"></typeparam>
    public class GenericList<Element> where Element : IComparable
    {
        private Element[] elements;
        private int count;
        private const int DefaultCapacity = 4;

        /// <summary>
        /// Create new list with specific length
        /// </summary>
        /// <param name="capacity"></param>
        public GenericList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Size must be non-negative number");
            }

            if (capacity > 0)
            {
                this.elements = new Element[capacity];
            }
            else
            {
                this.elements = new Element[DefaultCapacity];
            }

            this.count = 0;
        }

        /// <summary>
        /// Create new empty list
        /// </summary>
        public GenericList() : this(0)
        {
        }

        /// <summary>
        /// Count of elements in list
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
        }
        
        /// <summary>
        /// Add element to the end of the list
        /// </summary>
        /// <param name="element"></param>
        public void Add(Element element)
        {
            this.EnsureCapacity();

            this.elements[this.count] = element;
            this.count++;
        }

        /// <summary>
        /// Insert element at specific position
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void Insert(int index, Element element)
        {
            if (index < 0 || index > this.count)
            {
                throw new ArgumentOutOfRangeException("Index must be greater than zero and less than or equal to the list's elements count");
            }

            if (index == this.count)
            {
                this.Add(element);
            }
            else
            {
                this.EnsureCapacity();

                Array.Copy(this.elements, index, this.elements, index + 1, this.count - index);
                this.elements[index] = element;
                this.count++;
            }
        }

        /// <summary>
        /// Doubles the internal array's size if needed
        /// </summary>
        private void EnsureCapacity()
        {
            if (this.elements.Length == this.count)
            {
                int newCapacity = this.elements.Length * 2;
                if (newCapacity > int.MaxValue)
                {
                    newCapacity = int.MaxValue;
                }

                Array.Resize(ref this.elements, newCapacity);
            }
        }
        
        /// <summary>
        /// Set or get the element at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns> 
        public Element this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new ArgumentOutOfRangeException("Index must be greater than zero and less than the list's elements count");
                }

                return this.elements[index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new ArgumentOutOfRangeException("Index must be greater than zero and less than the list's elements count");
                }
                
                this.elements[index] = value;
            }
        }

        /// <summary>
        /// Find index of specific element by its value
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int Find(Element element)
        {
            return Array.IndexOf(elements, element);
        }

        /// <summary>
        /// Remove element at specific position
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("Index must be greater than zero and less than the list's elements count");
            }
            
            this.count--;
            if (index < this.count)
            {
                Array.Copy(this.elements, index + 1, this.elements, index, this.count - index);
            }
            this.elements[this.count] = default(Element);
        }

        /// <summary>
        /// Remove specific element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Remove(Element element)
        {
            int index = Array.IndexOf(this.elements, element);

            if (index >= 0)
            {
                this.RemoveAt(index);
                return true;
            }

            return false;
        } 

        /// <summary>
        /// Clear list
        /// </summary>
        public void Clear()
        {
            this.elements = new Element[DefaultCapacity];
            this.count = 0;
        }

        /// <summary>
        /// Find the element with minimal value
        /// </summary>
        /// <returns></returns>
        public Element Min()
        {
            if (this.count == 0)
            {
                throw new Exception("List is empty");
            }

            int minIndex = 0;

            for (int i = 1; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(this.elements[minIndex]) < 0)
                {
                    minIndex = i;
                }
            }

            return this.elements[minIndex];
        }

        /// <summary>
        /// Find the element with maximal value
        /// </summary>
        /// <returns></returns>
        public Element Max()
        {
            if (this.count == 0)
            {
                throw new Exception("List is empty");
            }

            int maxIndex = 0;

            for (int i = 1; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(this.elements[maxIndex]) > 0)
                {
                    maxIndex = i;
                }
            }

            return this.elements[maxIndex];
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string[] info = new string[this.count];

            for (int i = 0; i < this.count; i++)
            {
                info[i] = this.elements[i].ToString();
            }

            return "{ " + string.Join(", ", info) + " }";
        }
    }
}
