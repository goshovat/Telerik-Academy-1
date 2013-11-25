using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        private int lifetime;


        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime) : base(topLeft, body)
        {
            this.Lifetime = lifetime;
        }

        public int Lifetime
        {
            get
            {
                return this.lifetime;
            }
            set
            {
                if (this.lifetime < 0)
                {
                    throw new ArgumentException("Lifetime cannot be negative!");
                }
                this.lifetime = value;
            }
        }

        public override void Update()
        {
            this.Lifetime--;
            if (lifetime == 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
