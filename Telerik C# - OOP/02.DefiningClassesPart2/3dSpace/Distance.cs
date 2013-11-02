namespace _3dSpace
{
    using System;

    public static class Distance
    {
        // Write a static class with a static method to calculate the distance between two points in the 3D space.
        public static double CalculateDistanceBetweenTwoPoints(Point3D firstPoint, Point3D secondPoint)
        {
            double distance = Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2) + Math.Pow(firstPoint.Z - secondPoint.Z, 2));

            return distance;
        }
    }
}
