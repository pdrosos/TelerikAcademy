namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        /// <summary>
        /// Returns the sum of the items of a collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static decimal Sum<T>(this IEnumerable<T> collection)
        {
            decimal sum = 0;

            foreach (T item in collection)
            {
                sum += Convert.ToDecimal(item);
            }

            return sum;
        }

        /// <summary>
        /// Returns the average value of the sum of the items in a collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static decimal Average<T>(this IEnumerable<T> collection)
        {
            decimal sum = Sum(collection);

            return sum / collection.Count();
        }

        /// <summary>
        /// Returns the product of the items of a collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static decimal Product<T>(this IEnumerable<T> collection)
        {
            decimal product = 1;

            foreach (T item in collection)
            {
                product *= Convert.ToDecimal(item);
            }

            return product;
        }

        /// <summary>
        /// Returns the minimal value in a sequence of IComparable values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            T minValue = collection.First();

            foreach (T item in collection)
            {
                if (item.CompareTo(minValue) < 0) 
                {
                    minValue = item;
                }
            }

            return minValue;
        }

        /// <summary>
        /// Returns the maximal value in a sequence of IComparable values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            T maxValue = collection.First();

            foreach (T item in collection)
            {
                if (item.CompareTo(maxValue) > 0)
                {
                    maxValue = item;
                }
            }

            return maxValue;
        }
    }
}
