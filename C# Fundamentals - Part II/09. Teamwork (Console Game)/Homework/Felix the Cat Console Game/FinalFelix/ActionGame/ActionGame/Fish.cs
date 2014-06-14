using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionGame
{
    class Fish
    {
        public int x = 0;
        public int y = 0;
        public int height = 3;
        public int width = 5;

        public double health = 9;

        public char[,] fish = new char[3, 5] 
            {
                {' ','_', '_', ' ', ' '}, 
                {'/', 'o', ' ', '\\', '/'},
                {'\\', '_', '_', '/', '\\'}
            };

        public void Position(Imports.CharInfo[] matrix, Random r, int n)
        {

            int temp;
           // while (true)
            {
                temp = r.Next((Console.WindowWidth - width) - ActionGame.SideBarWidth);
            }
            x = temp;

        }

        public void Move(Imports.CharInfo[] matrix)
        {
            if (ActionGame.counter % 3 == 0)
            {
                y++;
            }
        }
    }
}
