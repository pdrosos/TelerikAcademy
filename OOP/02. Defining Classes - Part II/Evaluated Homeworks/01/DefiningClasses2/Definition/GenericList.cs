using System;
using System.Text;

public class GenericList<T>
where T: IComparable<T>
{
    public T[] arr;
    public int currentIndex;
    public GenericList(int capacity)
    {
        this.arr=new T[capacity];
        currentIndex = 0;
    }
    public void Add(T element)
    {
        Grow();
        arr[currentIndex] = element;
        currentIndex++;
    }
    public T Min()
    {
        T min = default(T);
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(min) <= 0)
            {
                min = arr[i];
            }
        }
        return min;
    }
    public T Max()
    {
        T max = default(T);
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(max) >= 0)
            {
                max = arr[i];
            }
        }
        return max;
    }
    private void Grow()
    {
        if (currentIndex >= arr.Length - 1)
        {
            T[] newArr = new T[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
        }
    }
    public T GetByIndex(int index)
    {
        if (index < 0 && index > arr.Length - 1)
        {
            throw new ArgumentOutOfRangeException();
        }
        return arr[index];
    }
    public void RemovingAt(int index)
    {
        if (index<0&&index>arr.Length-1)
        {
            throw new ArgumentOutOfRangeException();
        }
        T [] newArr=new T[arr.Length];
        for (int i = 0,j=0; i < arr.Length; i++,j++)
        {
            if (j==index)
            {
                i--;
                continue;                
            }
            newArr[i] = arr[j];
        }
        arr = newArr;
        currentIndex--;
    }
    public void InsertAt(T element,int index)
    {
        if (index < 0 && index > arr.Length - 1)
        {
            throw new ArgumentOutOfRangeException();
        }
        T[] newArr;
        if (currentIndex + 1 >= arr.Length)
        {
            newArr = new T[arr.Length * 2];
        }
        else
        {
            newArr = new T[arr.Length];
        }
        for (int i = 0, j = 0; i < arr.Length; i++, j++)
        {
            if (j == index)
            {
                newArr[i] = element;
                j--;
                continue;
            }
            newArr[i] = arr[j];
        }
        arr = newArr;
        currentIndex++;
    }
    public void Clear()
    {
        arr = new T[arr.Length];
    }
    public int Find(T element)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Equals(element))
            {
                return i;
            }
        }
        return -1;
    }
    public override string ToString()
    {
        StringBuilder result=new StringBuilder();
        foreach (var item in arr)
        {
            result.Append(item);
        }
        return result.ToString();
    }
}