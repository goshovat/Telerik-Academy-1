namespace Size
{
    using System;

    internal static class SizeRotation
    {
        public static Size GetRotatedSize(Size currentSize, double angleOfFigure)
        {
            double rotatedWidth = (Math.Abs(Math.Cos(angleOfFigure)) * currentSize.Width) +
                (Math.Abs(Math.Sin(angleOfFigure)) * currentSize.Height);
            double rotatedHeight = (Math.Abs(Math.Sin(angleOfFigure)) * currentSize.Width) +
                (Math.Abs(Math.Cos(angleOfFigure)) * currentSize.Height);

            return new Size(rotatedWidth, rotatedHeight);
        }
    }
}
