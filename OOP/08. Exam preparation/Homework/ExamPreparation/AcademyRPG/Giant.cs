namespace AcademyRPG
{
    using System.Collections.Generic;

    public class Giant : Character, IFighter, IGatherer
    {
        protected int attackPoints = 150;
        protected int bonusAttackPoints = 100;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.HasBonusAttackPoints = false;
        }

        public bool HasBonusAttackPoints { get; protected set; }

        public int AttackPoints
        {
            get 
            {
                if (this.HasBonusAttackPoints)
                {
                    return this.attackPoints + this.bonusAttackPoints;
                }

                return this.attackPoints; 
            }
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
                if (this.HasBonusAttackPoints == false) 
                {
                    this.HasBonusAttackPoints = true;
                }
                
                return true;
            }

            return false;
        }
    }
}
