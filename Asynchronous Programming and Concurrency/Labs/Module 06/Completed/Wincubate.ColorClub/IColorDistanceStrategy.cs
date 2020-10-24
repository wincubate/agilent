using System.Drawing;

namespace Wincubate.ColorClub
{
    public interface IColorDistanceStrategy
    {
        double ComputeDistance(Color e1, Color e2);
    }
}
