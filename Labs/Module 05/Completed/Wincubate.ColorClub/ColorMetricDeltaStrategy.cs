using System;
using System.Drawing;

namespace Wincubate.ColorClub
{
    public class ColorMetricDeltaStrategy : IColorDistanceStrategy
    {
        public double ComputeDistance(Color color1, Color color2)
        {
            long rmean = (color1.R + color2.R) / 2;
            long r = color1.R - color2.R;
            long g = color1.G - color2.G;
            long b = color1.B - color2.B;

            return Math.Sqrt((((512 + rmean) * r * r) >> 8) + 4 * g * g + (((767 - rmean) * b * b) >> 8));
        }
    }
}
