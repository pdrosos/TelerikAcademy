using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnpassableBlock : IndestructibleBlock
    {
        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
        }
    }
}
