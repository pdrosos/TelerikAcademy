using System;

namespace FelixTheCat.BlackHole
{
    /// <summary>
    /// Falling object with its shape and coordinates
    /// </summary>
    public class Figure : IEquatable<Figure>
    {
        private int startX;
        private int endY;
        private readonly string[,] symbols;
        private readonly ConsoleColor color;

        public int StartX
        {
            get { return startX; }
            set { startX = value; }
        }

        public int StartY
        {
            get { return endY - Height + 1; }
        }

        public int EndX
        {
            get { return startX + Width - 1; }
        }

        public int EndY
        {
            get { return endY; }
            set { endY = value; }
        }

        public int Height
        {
            get { return symbols.GetLength(0); }
        }

        public int Width
        {
            get { return symbols[0, 0].Length; }
        }

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }
        }

        public string[,] Symbols
        {
            get
            {
                return this.symbols;
            }
        }

        public Figure(string[,] symbols, ConsoleColor color, int startX, int endY)
        {
            this.symbols = symbols;
            this.color = color;
            this.startX = startX;
            this.endY = endY;
        }

        public void MoveDown()
        {
            endY++;
        }

        public bool Equals(Figure figure)
        {
            if (symbols == figure.symbols && color == figure.color)
            {
                return true;    
            }

            return false;
        }
    }
}
