namespace AcademyRPG
{
    using System.Collections.Generic;

    public class Ninja : Character, IFighter, IGatherer
    {
        protected int attackPoints = 0;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int highestHitPoints = -1;
            int targetIndex = -1;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (highestHitPoints < availableTargets[i].HitPoints) 
                    {
                        highestHitPoints = availableTargets[i].HitPoints;
                        targetIndex = i;
                    }
                }
            }

            return targetIndex;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }

            return false;
        }
    }
}
