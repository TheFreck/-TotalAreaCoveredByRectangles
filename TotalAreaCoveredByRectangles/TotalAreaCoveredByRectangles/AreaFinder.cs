using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalAreaCoveredByRectangles
{
    public class AreaFinder
    {
        public static List<int[]> Rectangles = new List<int[]>();
        public static long Calculate(IEnumerable<int[]> rectangles)
        {
            if (rectangles.ToArray().Length <= 0) return 0;
            long area = 0;
            for (var x = rectangles.Min(r => r[0]) + 1; x <= rectangles.Max(r => r[2]); x++)
            {
                var rects = rectangles.Where(r => r[0] < x && r[2] >= x).ToArray();
                long upperRange = rects.Length > 0 ? rects.Max(r => r[3]) : 0;
                long lowerRange = rects.Length > 0 ? rects.Min(r => r[1]) + 1 : 1;
                HashSet<long> lineArea = new HashSet<long>();
                for (var y = lowerRange; y <= upperRange; y++)
                {
                    foreach(var rectangle in rects)
                    {
                        if (rectangle[1] < y && y <= rectangle[3])
                        {
                            lineArea.Add(y); 
                            break;
                        }
                    }
                }
                area += lineArea.Count();
            }
            return area;
        }

        public static long CalculatePoints(IEnumerable<(int, long, long)> polygon, IEnumerable<int[]> rectangles)
        {
            var poly = polygon as List<(int,long,long)> ?? polygon.ToList();
            var rect = rectangles as List<int[]> ?? rectangles.ToList();
            if (poly.Count <= 0 || rect.Count <= 0) return 0;
            var hash = new HashSet<string>();
            var min = poly.OrderByDescending(a => a.Item1).LastOrDefault().Item1;
            var max = poly.OrderByDescending(a => a.Item1).FirstOrDefault().Item1;
            for (var i = min; i <= max; i++)
            {
                var thisItem = poly.Where(p => p.Item1 == i).FirstOrDefault();
                for (var j = thisItem.Item2+1; j <= thisItem.Item3; j++)
                {
                    var currentRects = rectangles.Where(r => i > r[0] && i <= r[2]).ToList();
                    var low = currentRects.OrderByDescending(r => r[1]).LastOrDefault()[1];
                    var high = currentRects.OrderByDescending(r => r[3]).FirstOrDefault()[3];
                    if(j>low && j <= high)
                    {
                        hash.Add($"{i},{j}");
                        break;
                    }
                }
            }

            return hash.Count;
        }

        public static List<int[]> GenerateRectangles(int input)
        {
            var randy = new Random();
            for (var i = 0; i < input; i++)
            {
                var x1 = randy.Next(1000);
                var y1 = randy.Next(1000);
                var x2 = randy.Next(x1, x1+1000);
                var y2 = randy.Next(y1, y1+1000);
                Rectangles.Add([x1, y1, x2, y2]);
            }

            return Rectangles;
        }

        public static List<List<(int, int)>> FindCoveredRectangles(List<int[]> rectangles)
        {
            var polygon = new List<List<(int,int)>>();
            //var byLeftEdge = rectangles.OrderBy(r => r[0]).GroupBy(r => r[0]).ToList();
            for(var x=rectangles.Min(r => r[0]); x<rectangles.Max(r => r[2]); x++)
            {
                var xRectangles = rectangles.Where(r => r[0] < x && x <= r[2]).ToList();
                if (xRectangles.Count == 0) continue;
                foreach(var rect in rectangles)
                {
                var xContainers = new List<(int, int)> { (xRectangles[0][1], xRectangles[0][3]) };
                    var gaps = new List<(int,int)>();
                    for(var i=0; i< xContainers.Count; i++)
                    {
                        if (rect[1] > xContainers[i].Item2 || rect[3] < xContainers[i].Item1)
                        {
                            // gap
                            xContainers.Add((rect[1], rect[3]));
                        }
                        else
                        {
                            xContainers[i] = new (Math.Min(xContainers[i].Item1, rect[1]), Math.Max(xContainers[i].Item2, rect[3]));
                        }
                    }
                polygon.Add(xContainers);
                }
            }

            return polygon;
        }

        public static object CompareRectangles(List<int[]> input)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for(var i=0; i < input.Count; i++)
            {
                for(var j=i+1; j < input.Count; j++)
                {
                    //if (input[i][0] <= input[j][0] && input)
                }
            }
            throw new NotImplementedException();
        }
    }
}
