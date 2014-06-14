using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionGame
{
    class Weapon
    {
        public int x;
        public int y;
        public Imports.CharInfo weapon;

        public bool IsTheFishShooted = false;


        public void WeaponKind(int n)
        {
            switch (n)
            {
                case 1: weapon.Char.UnicodeChar = '|'; weapon.Attributes = 7; break;
                case 2: weapon.Char.UnicodeChar = '.'; weapon.Attributes = 7; break;
                case 3: weapon.Char.UnicodeChar = 'O'; weapon.Attributes = 7; break;
            }
        }

        public void SetWeaponPos(Felix f)
        {
            x = f.x;
            y = f.y - 1;
        }

        public bool checkIfCellIsEmpty(int x, int y, Imports.CharInfo[] matrix, int n)
        {
            if (matrix[x + (y + n)].Char.UnicodeChar == '\0')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Shoot()
        {
            if (y > 0)
            {
                {
                    y--;
                    //if (checkIfCellIsEmpty(x, y - 1, matrix))
                    {
                        IsTheFishShooted = true;
                    }
                    //  else
                    {
                        //     IsTheFishShooted = false;
                    }
                }
            }
        }
    }
}
