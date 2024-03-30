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
            var intsEnumerable = rectangles as int[][] ?? rectangles.ToArray();
            if (intsEnumerable.ToList().Count <= 0) return 0;
            var hash = new HashSet<string>();
            var fakeHash = new List<string>();
            long area = 0;
            for (var x = intsEnumerable.Min(r => Math.Min(r[0]+1, r[2])); x <= intsEnumerable.Max(r => Math.Max(r[0],r[2])); x++)
            {
                var items = intsEnumerable.Where(r => Math.Min(r[0], r[2]) < x && Math.Max(r[0], r[2]) >= x).ToArray();
                long upperRange = items.Length > 0 ? items.Max(r => Math.Max(r[1], r[3])) : 0;
                long lowerRange = items.Length > 0 ? items.Min(r => Math.Min(r[1], r[3])) : 0;
                area += upperRange > 0 && upperRange > lowerRange ? upperRange-lowerRange : 0;
            }

            return area;
        }

        public static List<int[]> GenerateRectangles(int input)
        {
            var randy = new Random();
            var rectangles = new List<int[]>();
            for (var i = 0; i < input; i++)
            {
                var x1 = randy.Next(1000000);
                var y1 = randy.Next(1000000);
                var x2 = randy.Next(x1, 1000000);
                var y2 = randy.Next(y1, 1000000);
                rectangles.Add([x1, y1, x2, y2]);
            }

            return rectangles;
        }
    }
}
