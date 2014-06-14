namespace StringBuilderExtensions
{
    using System;
    using System.Text;

    /// <summary>
    /// StringBuilder extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Retrieves a substring from this instance. 
        /// The substring starts at a specified character position and has a specified length.
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static StringBuilder Substring(this StringBuilder stringBuilder, int index, int length)
        {
            return new StringBuilder(stringBuilder.ToString(index, length));
        }

        /// <summary>
        /// Retrieves a substring from this instance. 
        /// The substring starts at a specified character position and continues to the end of the string.
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static StringBuilder Substring(this StringBuilder stringBuilder, int index)
        {
            return new StringBuilder(stringBuilder.ToString(index, stringBuilder.Length - index));
        }
    }
}
