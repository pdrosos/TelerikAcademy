using System;
using System.Text;

class GenericList<T> 
    where T: IComparable, IComparable<T>
{
    //Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
    
    //Implement methods for adding element, accessing element by index, removing element by index, 
    //inserting element at given position, clearing the list, finding element by its value and ToString(). 
    //Check all input parameters to avoid accessing elements at invalid positions.

    private T[] elements;
    private int count = 0;

    //Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
    public GenericList(int capacity)
    {
        elements = new T[capacity];
    }

    public int Count
    {
        get { return this.count; }
    }

    //Adding element
    public void Add(T element)
    {
        if (count >= elements.Length)
        {
            this.EnsureCapacity();
        }

        this.elements[count] = element;
        count++;
    }
    
    //Removing last element
    public void Remove()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("This list is empty");
        }

        T[] result = new T[this.count - 1];

        for (int i = 0; i < this.count-1; i++)
        {
            result[i] = elements[i];
        }

        //we overwrite the list with the newly generated
        this.elements = result;
        count--;
    }

    //Removing element by index
    public void RemoveAt(int index)
    {
        if (index >= count || index < 0)
        {
            throw new IndexOutOfRangeException(String.Format(
                "Invalid index: {0}.", index));
        }

        if (index == this.count - 1)
        {
            //if the index is the last we use the remove method above
            this.Remove();
        }
        else
        {
            T[] result = new T[elements.Length];

            //we just copy the elements with index less than the remove point
            for (int i = 0; i < index; i++)
            {
                result[i] = elements[i];
            }

            //we skip the element to be removed and copy the rest of the array
            for (int i = index + 1; i < this.count; i++)
            {
                result[i-1] = elements[i];
            }

            //we overwrite the list with the newly generated
            this.elements = result;
            count--;
        }
    }

    //Accessing element by index
    public T this[int index]
    {
        get
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0}.", index));
            }
            T result = elements[index];
            return result;
        }

        set
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException(String.Format(
                    "Invalid index: {0}.", index));
            }
            elements[index] = value;
        }
    }

    //inserting element at given position
    public void AddAt(int index, T element)
    {
        if (index >= count || index < 0)
        {
            throw new IndexOutOfRangeException(String.Format(
                "Invalid index: {0}.", index));
        }
        
        if (count >= elements.Length)
        {
            this.EnsureCapacity();
        }

        T[] result = new T[elements.Length];

        //we just copy the elements with index less than the adding point
        for (int i = 0; i < index; i++)
        {
            result[i] = elements[i];
        }

        //we add the element at the index position
        result[index] = element;

        for (int i = index; i < this.count; i++)
        {
            result[i + 1] = elements[i];
        }

        //we overwrite the list with the newly generated
        this.elements = result;
        count++;
    }

    //clearing the list
    public void ClearList()
    {
        T[] newList = new T[elements.Length];
        this.elements = newList;
        count = 0;
    }

    //finding element by its value - I understand it as finding its index
    public int IndexOf(T element)
    {
        for (int i = 0; i < this.count; i++)
        {
            if (element.CompareTo(elements[i]) == 0)
            {
                return i;
            }
        }

        //if we don't find a match the default is -1
        return -1;
    }

    //Implement auto-grow functionality: when the internal array is full, 
    //create a new array of double size and move all elements to it.
    private void EnsureCapacity()
    {
        T[] newList = new T[elements.Length * 2];

        for (int i = 0; i < elements.Length; i++)
        {
            newList[i] = elements[i];
        }

        this.elements = newList;
    }

    //Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>. 
    //You may need to add a generic constraints for the type T.
    //Added IComparable - you need that for the IndexOf method too
    public T Min()
    {
        if (count == 1)
        {
            throw new InvalidOperationException("We need at lest 2 elements in order to compare them");
        }
        
        T min = elements[0];

        for (int i = 1; i < this.count; i++)
        {
            if (min.CompareTo(elements[i]) > 0)
            {
                min = elements[i];
            }
        }

        return min;
    }

    public T Max()
    {
        if (count == 1)
        {
            throw new InvalidOperationException("We need at lest 2 elements in order to compare them");
        }

        T max = elements[0];

        for (int i = 1; i < this.count; i++)
        {
            if (max.CompareTo(elements[i]) < 0)
            {
                max = elements[i];
            }
        }

        return max;
    }

    //ToString()
    public override string ToString()
    {
        if (count == 0)
        {
            Console.WriteLine("This list is empty!");
        }

        StringBuilder print = new StringBuilder();

        for (int i = 0; i < this.count; i++)
        {
            print.Append(elements[i]);
            print.AppendLine();
        }

        string result = print.ToString();

        return result;
    }
}

