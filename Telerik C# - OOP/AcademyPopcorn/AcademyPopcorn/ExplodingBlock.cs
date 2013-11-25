using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public new const string CollisionGroupString = "exploadingBlock";

        public ExplodingBlock(MatrixCoords topLeft) : base(topLeft)
        {
            this.body[0, 0] = '§';
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> explosives = new List<GameObject>();
            if (this.IsDestroyed)
            {

                explosives.Add(new Explosive(this.topLeft, new char[,] { { '~' } }, new MatrixCoords(1, 0)));

                explosives.Add(new Explosive(this.topLeft, new char[,] { { '~' } }, new MatrixCoords(1, 1)));

                explosives.Add(new Explosive(this.topLeft, new char[,] { { '~' } }, new MatrixCoords(1, -1)));

                explosives.Add(new Explosive(this.topLeft, new char[,] { { '~' } }, new MatrixCoords(0, 1)));

                explosives.Add(new Explosive(this.topLeft, new char[,] { { '~' } }, new MatrixCoords(0, -1)));

                explosives.Add(new Explosive(this.topLeft, new char[,] { { '~' } }, new MatrixCoords(-1, 0)));

                explosives.Add(new Explosive(this.topLeft, new char[,] { { '~' } }, new MatrixCoords(-1, 1)));

                explosives.Add(new Explosive(this.topLeft, new char[,] { { '~' } }, new MatrixCoords(-1, -1)));
            }

            return explosives;
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

    }
}
