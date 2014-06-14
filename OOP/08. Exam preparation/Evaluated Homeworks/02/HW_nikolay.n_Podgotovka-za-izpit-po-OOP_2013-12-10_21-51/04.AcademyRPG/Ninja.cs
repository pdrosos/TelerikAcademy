using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class Ninja: Character, IFighter, IGatherer
    {
        private int initialAttackPoints = 0;
        public Ninja(string name, Point position, int owner):base(name,position,owner)
        {
            this.HitPoints = 1;
        }

        public int AttackPoints
        {
            get { return this.initialAttackPoints; }
            private set { this.initialAttackPoints= value; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int target = -1;
            int maxHitPoints = 0;
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if(availableTargets[i].Owner != 0 && availableTargets[i].Owner != this.Owner)
                {
                    if(availableTargets[i].HitPoints > maxHitPoints)
                    {
                        maxHitPoints = availableTargets[i].HitPoints;
                        target = i;
                    }
                }
            }

            return target;
        }

        public bool TryGather(IResource resource)
        {
            if(resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity*2;
                return true;
            }
            else if(resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }

            return false;
        }
    }
}
