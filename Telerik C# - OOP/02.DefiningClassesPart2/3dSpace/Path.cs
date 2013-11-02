namespace _3dSpace
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        // Create a class Path to hold a sequence of points in the 3D space. 
        private List<Point3D> pathPoints = new List<Point3D>();

        public List<Point3D> PathPoints
        {
            get
            {
                return this.pathPoints;
            }
        }

        public void Add(int x = 0, int y = 0, int z = 0)
        {
            this.pathPoints.Add(new Point3D() { X = x, Y = y, Z = z });
        }

        public void Remove(int x, int y, int z)
        {
            this.pathPoints.Remove(new Point3D() { X = x, Y = y, Z = z });
        }

        public void Clear()
        {
            this.pathPoints.Clear();
        }

        public Point3D this[int index]
        {
            get
            {
                return this.pathPoints[index];
            }
        }
    }
}