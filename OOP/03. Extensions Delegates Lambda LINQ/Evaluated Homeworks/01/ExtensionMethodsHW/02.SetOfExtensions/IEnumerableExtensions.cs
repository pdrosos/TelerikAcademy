using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SetOfExtensions
{
    //delegate for the method which will be passed to retrieve the required numeral value
    //for executing the methods Sum, Average, Product for user defined types
    public delegate decimal CustomNumberType<T>(T ob);

    public static class IEnumerableExtensions 
    {
        //version for numeral types
        public static decimal Sum<T>(this IEnumerable<T> array)
            where T : struct, IComparable<T>, IConvertible
        //with these constraints only numerical types will work (AND any other user defined types which implement those interfaces)
        {
            decimal sum = 0;

            foreach  (T element in array)
            {
                dynamic e = element;
                sum += e;
            }

            return sum;
        }

       
        public static decimal Average<T>(this IEnumerable<T> en)
          where T : struct, IComparable<T>, IConvertible
        {
            decimal sum = 0;
            int count = 0;

            foreach (T element in en)
            {
                dynamic e = element;
                sum += e;
                count++;
            }

            return sum / count;
        }
               
        public static decimal Product<T>(this IEnumerable<T> en)
          where T : struct, IComparable<T>, IConvertible
        {
            decimal product = 1;
            
            foreach (T element in en)
            {
                dynamic e = element;
                product *= e;
                
            }

            return product;
        }
                
        public static T Min<T>(this IEnumerable<T> en) where T : IComparable<T>
        {
            T min = en.First();

            foreach (T element in en)
            {
                dynamic e = element;
                if (e.CompareTo(min) < 0)
                {
                    min = element;
                }
            }

            return min;
        }


        public static T Max<T>(this IEnumerable<T> en) where T : IComparable<T>
        {
            T max = en.First();

            foreach (T element in en)
            {
                dynamic e = element;
                if (e.CompareTo(max) > 0)
                {
                    max = element;
                }
            }

            return max;
        }

        //this versions are for user defined types (classes structures etc)
        public static decimal Sum<T>(this IEnumerable<T> en, CustomNumberType<T> numValue)
        {
            decimal sum = 0;

            foreach (T element in en)
            {
                dynamic e = element;
                sum += numValue(element);
            }

            return sum;
        }

        public static decimal Average<T>(this IEnumerable<T> en, CustomNumberType<T> numValue)
        {
            decimal sum = 0;
            int count = 0;

            foreach (T element in en)
            {
                dynamic e = element;
                sum += numValue(element);
                count++;
            }

            return sum / count;
        }

        public static decimal Product<T>(this IEnumerable<T> en, CustomNumberType<T> numValue)
        {
            decimal product = 1;

            foreach (T element in en)
            {
                dynamic e = element;
                product *= numValue(element);

            }

            return product;
        }

    
        }
}
