using System;
using System.Collections.Generic;
using System.Linq;

namespace ApacheCombat
{
    class Helicopter
    {
        private int startX;
        private int startY;

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
        
        private List<string> helicopterRows = new List<string>()
        {
            "    ------- # -------",
            "###     -******-     ",
            "**********#    ***   ",
            " #      *******      "
        };

        public int EndX
        {
            get { return startX + helicopterRows[0].Length - 1; }
        }

        public int EndY
        {
            get { return startY + helicopterRows.Count - 1; }
        }

        public int Height
        {
            get { return helicopterRows.Count; }
        }
        public int Width
        {
            get { return helicopterRows[0].Length; }
        }

        public static void SetPosition(Helicopter helicopter)
        {
            helicopter.StartX = 15;
            helicopter.StartY = Console.WindowHeight / 2 - helicopter.Height / 2 - 2;               
        }
        public static void Draw(Helicopter helicopter)
        {

            int helicopterPositionY = helicopter.StartY;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (var helicopterRow in helicopter.helicopterRows)
            {
                Console.SetCursorPosition(helicopter.StartX, helicopterPositionY);

                Console.WriteLine(helicopterRow);
                helicopterPositionY++;
            }
            Console.ResetColor();
        }

        public static void MoveUp(Helicopter helicopter)
        {
            if (helicopter.StartY > 0)
            {
                helicopter.StartY--;
            }

        }
        public static void MoveDown(Helicopter helicopter)
        {
            if (helicopter.StartY + helicopter.Height - 1 < Console.WindowHeight - 1)
            {
                helicopter.StartY++;
            }

        }
    }
}
