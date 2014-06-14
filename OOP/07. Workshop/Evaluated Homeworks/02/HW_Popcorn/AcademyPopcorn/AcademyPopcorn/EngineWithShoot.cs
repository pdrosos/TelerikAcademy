using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class EngineWithShoot : Engine
    {
        // Task 4 - I don't understand why do I had to create this class?!?!?
        public EngineWithShoot(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : base(renderer, userInterface, sleepTime)
        {
        }

    }
}
