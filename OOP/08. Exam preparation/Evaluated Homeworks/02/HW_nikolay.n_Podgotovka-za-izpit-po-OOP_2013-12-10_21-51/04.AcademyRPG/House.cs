using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class House: StaticObject
    {
        public House(Point position, int owner):base(position,owner)
        {
            this.HitPoints = 500;
        }
    }
}
