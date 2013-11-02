namespace _3dSpace
{
    public struct Point3D
    {
        // Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
        private int x;
        private int y;
        private int z;

        // Properties
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        
        public int Z
        {
            get { return z; }
            set { z = value; }
        }

        // Implement the ToString() to enable printing a 3D point.
        public override string ToString()
        {
            return string.Format("Point Coordinate: \nX = {0}\nY = {1}\nZ = {2}", X, Y, Z);
        }

        // Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
        private static readonly Point3D centerOfTheCoordinateSystem = new Point3D() { X = 0, Y = 0, Z = 0 };

        // Add a static property to return the point O.
        public static Point3D CenterOfTheCoordinateSystem
        {
            get { return Point3D.centerOfTheCoordinateSystem; }
        }
    }
}