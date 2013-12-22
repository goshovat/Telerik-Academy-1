using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private int attackPoints;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.AttackPoints = 0;
        }

        public bool isDestroyed
        {
            get { return false; }
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            private set
            {
                this.attackPoints = value;
            }
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }

            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
        
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int maxHitPoints = -1;
            int indexOfTheTarget = -1;
            bool hasTarget = false;
            
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (maxHitPoints < availableTargets[i].HitPoints)
                    {
                        maxHitPoints = availableTargets[i].HitPoints;
                        indexOfTheTarget = i;
                        hasTarget = true;
                    }
                }
            }

            if (hasTarget)
            {
                return indexOfTheTarget;
            }

            return -1;
        }


        public int DefensePoints
        {
            get { return int.MaxValue; }
        }
    }
}
