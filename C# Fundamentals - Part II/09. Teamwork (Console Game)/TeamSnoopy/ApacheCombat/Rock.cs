using System;
using System.Linq;

namespace ApacheCombat
{
    class Rock
    {
        private int startX;
        private int startY;
        private string[,] rockElements;

        public string[,] RockElements
        {
            get
            {
                return this.rockElements;
            }
        }

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
        public int EndX
        {
            get { return startX + rockElements.GetLength(1) - 1; }
        }
        public int EndY
        {
            get { return startY + rockElements.GetLength(0) - 1; }
        }
        public int Height
        {
            get { return rockElements.GetLength(0); }
        }
        public int Width
        {
            get { return rockElements.GetLength(1); }
        }

        public Rock(string[,] rockElements, int startX, int startY)
        {
            this.rockElements = rockElements;
            this.startX = startX;
            this.startY = startY;
        }

        public static void MoveLeft(Rock rock)
        {
            rock.StartX--;
        }

        public static void Draw(Rock rock)
        {
            int firstColumn; //rock's first column that should be printed on the console
            int lastColumn; //rock's last column that should be printed on the console
            int currentRow = rock.StartY;

            for (int row = 0; row < rock.Height; row++)
            {
                firstColumn = 0;

                if (rock.StartX < 0)
                {
                    Console.SetCursorPosition(0, currentRow);
                    firstColumn = (-1) * rock.StartX;
                }
                else
                {
                    Console.SetCursorPosition(rock.StartX, currentRow);
                }


                if (ApacheCombat.consoleWindowWidth - rock.StartX + 1 > rock.Width)
                {
                    lastColumn = rock.Width;
                }
                else
                {
                    lastColumn = ApacheCombat.consoleWindowWidth - rock.StartX + 1;
                }

                for (int col = firstColumn; col < lastColumn; col++)
                {
                    Console.Write(rock.RockElements[row, col]);
                }

                currentRow++;
            }
        }


    }
}
