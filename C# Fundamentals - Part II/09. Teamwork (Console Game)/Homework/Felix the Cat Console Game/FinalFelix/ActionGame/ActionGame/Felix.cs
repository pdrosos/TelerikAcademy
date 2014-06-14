using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ActionGame
{
    class Felix
    {

        public char felix = '⎔';
        public int x;
        public int y;


        public void setFelixPos()
        {
            x = (Console.WindowWidth - ActionGame.SideBarWidth) / 2;
            y = Console.WindowHeight - 2;
        }

        public bool checkIfCellIsEmpty(int x, int y, Imports.CharInfo[] matrix, int n)
        {
            if (matrix[x + (y * n)].Char.UnicodeChar == ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Move(Imports.CharInfo[] matrix, int n)
        {
            var left = Imports.GetKeyState(VirtualKeyStates.VK_LEFT) & 0x8000;
            var right = Imports.GetKeyState(VirtualKeyStates.VK_RIGHT) & 0x8000;
            if (left > 0)
            {
                if (x > 0)
                {
                    if (checkIfCellIsEmpty(x - 1, y, matrix, n))
                    {
                        x--;
                    }
                    else
                    {
                        //game end
                    }
                }
            }
            if (right > 0)
            {
                if (x < (Console.WindowWidth - 2 - ActionGame.SideBarWidth))
                {
                    if (checkIfCellIsEmpty(x + 1, y, matrix, n))
                    {
                        x++;
                    }
                    else
                    {
                        //game end
                    }
                }
            }
        }
    }

}
