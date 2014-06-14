using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class Giant: Character, IFighter, IGatherer
    {
        private int initialAttackPoints = 150;
        private bool gainedAttack = false;
        public Giant(string name, Point position, int owner = 0):base(name,position,owner)
        {
            this.HitPoints = 200;
        }

        public int AttackPoints
        {
            get { return initialAttackPoints; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if(availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if(resource.Type == ResourceType.Stone)
            {                
                if(!this.gainedAttack)
                {
                    this.gainedAttack = true;
                    this.initialAttackPoints += 100;
                }
                return true;
            }

            return false;
        }
    }
}
