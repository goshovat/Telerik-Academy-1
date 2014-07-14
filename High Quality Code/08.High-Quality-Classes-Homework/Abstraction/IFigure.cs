namespace Shapes
{
    internal interface IFigure
    {
        /// <summary>
        /// Calculate the perimeter of the figure.
        /// </summary>
        /// <returns>Returns the perimeter of the figure</returns>
        double CalcPerimeter();

        /// <summary>
        /// Calculate the surface of the figure.
        /// </summary>
        /// <returns>Returns the surface of the figure</returns>
        double CalcSurface();
    }
}
