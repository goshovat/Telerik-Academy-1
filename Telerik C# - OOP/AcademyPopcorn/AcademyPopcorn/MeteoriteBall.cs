using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        public List<TrailObject> trailObjects;
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed) : base(topLeft, speed)
        {
        }
        
        
        public override void Update()
        {
            base.Update();
            this.trailObjects = new List<TrailObject>();
            this.trailObjects.Add(new TrailObject(this.topLeft, new char[,] { { '.' } }, 3));
            
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            return this.trailObjects;
        }
    }
}
