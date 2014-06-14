using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class IEnumerableExtension
{
    //02.Implement a set of extension methods for IEnumerable<T> that implement 
    //the following group functions: sum, product, min, max, average.

    public static T Min<T>(this IEnumerable<T> enumeration)
        where T : IComparable<T>
    {
        if (enumeration.Count() == 0)
        {
            throw new ArgumentException("The enumeration is empty!");
        }

        dynamic min = enumeration.First();
        foreach (var num in enumeration)
        {

            if (num.CompareTo(min) < 0)
            {
                min = num;
            }

        }
        return min;
    }

    public static T Max<T>(this IEnumerable<T> enumeration)
        where T: IComparable<T>
    {
        if (enumeration.Count() == 0)
        {
            throw new ArgumentException("The enumeration is empty!");
        }

        dynamic max = enumeration.First();
        foreach (var num in enumeration)
        {
            if (num.CompareTo(max) > 0)
            {
                max = num;
            }
        }

        return max;
    }

    public static decimal Sum<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() == 0)
        {
            throw new ArgumentException("The enumeration is empty!");
        }

        decimal sum = 0;
        foreach (var num in enumeration)
        {
            sum += Convert.ToDecimal(num);
        }

        return sum;
    }

    public static decimal Product<T>(this IEnumerable<T> enumeration)
    {
        decimal product = 1;
        foreach (var num in enumeration)
        {
            product *= Convert.ToDecimal(num);
        }

        return product;
    }

    public static decimal Average<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() == 0)
        {
            throw new ArgumentException("The enumeration is empty!");
        }

        decimal average = 0;
        int counter = 1;
        foreach (var item in enumeration)
        {
            average += Convert.ToDecimal(item);
            counter++;
        }

        return average / counter;
    }


}

