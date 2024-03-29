using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalAreaCoveredByRectangles
{
    public class AreaFinder
    {
        public static long Calculate(IEnumerable<int[]> rectangles)
        {
            var areas = new List<int>();
            foreach(var rectangle in rectangles)
            {
                var topLeft = Tuple.Create(rectangle[0], rectangle[1]);
                var topRight = Tuple.Create(rectangle[2], rectangle[1]);
                var bottomLeft = Tuple.Create(rectangle[0], rectangle[3]);
                var bottomRight = Tuple.Create(rectangle[2], rectangle[3]);
                areas.Add((topRight.Item1 - topLeft.Item1) * (bottomRight.Item2 - bottomLeft.Item2));
            }
            return areas.Sum();
        }
    }
}
