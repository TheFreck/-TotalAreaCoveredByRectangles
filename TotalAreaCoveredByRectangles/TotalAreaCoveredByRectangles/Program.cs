using System.Diagnostics;
using TotalAreaCoveredByRectangles;

Console.WriteLine("How many rectangles?");
var rects = Console.ReadLine();
if(int.TryParse(rects, out var rectsCount))
{
    var rectangles = AreaFinder.GenerateRandomRectangles(rectsCount); 
    //var proceed = false;
    //var groups = rectangles.Select((r, i) => new { Index = i, Value = r }).GroupBy(r => r.Index / 1000).Select(r => r.Select(v => v.Value).ToList()).ToList();
    //var groupCount = 0;
    //do
    //{
    //    if (groupCount >= groups.Count)
    //    {
    //        proceed = false;
    //    }
    //    else
    //    {
    //        foreach (var rectangle in groups[groupCount])
    //        {
    //            Console.WriteLine($"[{rectangle[0]},{rectangle[1]},{rectangle[2]},{rectangle[3]}]");
    //        }
    //        var keepGoing = Console.ReadLine();
    //        if(keepGoing != null)
    //        {
    //            proceed = true;
    //        }
    //        else
    //        {
    //            proceed= false;
    //        }
    //    }
    //    groupCount++;
    //} while (proceed);
    var stopwatch = new Stopwatch();
    Console.WriteLine("How many times shall we run?");
    var loops = Console.ReadLine();
    if(int.TryParse(loops, out var loopsCount))
    {
        Console.WriteLine("starting");
        for(var i=0; i< loopsCount; i++)
        {
            long area = 0;
            stopwatch.Start();
            area = AreaFinder.Calculate(rectangles);
            stopwatch.Stop();
            Console.WriteLine($"Area: {area}; Elapsed Time: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Reset();
        }
        
    }
}

