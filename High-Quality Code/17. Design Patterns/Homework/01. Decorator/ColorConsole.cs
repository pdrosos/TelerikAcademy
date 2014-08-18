// ********************************
// <copyright file="ColorConsole.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
// <author>Telerik Student</author>
// ********************************
namespace Decorator
{
    using System;
  
    public static class ColorConsole : object
    {
        public static void Write(char input)
        {
            Write<char>(input, ConsoleColor.Gray);
        }

        public static void Write(char input, ConsoleColor color)
        {
            Write<char>(input, color);
        }

        public static void Write(string input)
        {
            Write<string>(input, ConsoleColor.Gray);
        }

        public static void Write(string input, ConsoleColor color)
        {
            Write<string>(input, color);
        }

        public static void WriteLine(char input)
        {
            WriteLine<char>(input, ConsoleColor.Gray);
        }

        public static void WriteLine(char input, ConsoleColor color)
        {
            WriteLine<char>(input, color);
        }

        public static void WriteLine(string input)
        {
            WriteLine<string>(input, ConsoleColor.Gray);
        }

        public static void WriteLine(string input, ConsoleColor color)
        {
            WriteLine<string>(input, color);
        }

        public static void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        private static void Write<T>(T input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(input.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void WriteLine<T>(T input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
