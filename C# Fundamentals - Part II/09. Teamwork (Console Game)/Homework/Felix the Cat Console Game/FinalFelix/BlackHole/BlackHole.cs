using System;

namespace FelixTheCat.BlackHole
{
    /// <summary>
    /// Black hole with its shape and coordinates
    /// </summary>
    public class BlackHole
    {
        private int startX;
        private int startY;
        private readonly string[,] symbols;
        private readonly ConsoleColor color;

        public int StartX
        {
            get { return startX; }
            set { startX = value; }
        }

        public int StartY
        {
            get { return startY; }
            set { startY = value; }
        }

        public int EndY
        {
            get { return StartY + Height - 1; }
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

        public BlackHole(string[,] symbols, ConsoleColor color, int startX, int startY)
        {
            this.symbols = symbols;
            this.color = color;
            this.startX = startX;
            this.startY = startY;
        }
    }
}
