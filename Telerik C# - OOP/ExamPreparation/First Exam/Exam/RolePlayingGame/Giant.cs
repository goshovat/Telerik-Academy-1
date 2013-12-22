using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private int attackPoints;

        private bool isAttackPointsIncreased;
        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.isAttackPointsIncreased = false;
            this.attackPoints = 150;
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

        public int DefensePoints
        {
            get { return 80; }
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!this.isAttackPointsIncreased)
                {
                    this.AttackPoints += 100;
                    this.isAttackPointsIncreased = true;
                }
                return true;
            }

            return false;
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
