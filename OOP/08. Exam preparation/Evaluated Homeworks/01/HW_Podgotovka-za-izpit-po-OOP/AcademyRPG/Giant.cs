using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private bool isEnhanced;
        private int attackPoints;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.isEnhanced = false;
            this.attackPoints = 150;
            this.HitPoints = 200;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!isEnhanced)
                {
                    this.attackPoints += 100;
                    this.isEnhanced = true;
                }

                return true;
            }
            return false;
        }
    }
}
