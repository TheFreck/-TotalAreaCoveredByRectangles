using Machine.Specifications;
using System.Collections;
using System.Diagnostics;

namespace TotalAreaCoveredByRectangles.Specs
{
    public class When_Finding_The_Area_Of_Rectangles
    {
        Establish context = () =>
        {
            input = new List<int[]>
            {
                new int[]{0,0,10,10},
                new int[]{11,0,21,21}
            };
            expect = 310;
        };

        Because of = () => answer = AreaFinder.Calculate(input);

        It Should_Return_An_Integer_Area = () => answer.ShouldEqual(expect);

        private static IEnumerable<int[]> input;
        private static int expect;
        private static long answer;
    }

    public class When_Accounting_For_Overlaps
    {
        Establish context = () =>
        {
            input = new List<int[]>
            {
                new [] {0, 0, 10, 10},
                new [] {5, 0, 15, 10}
            };
            expect = 150;
        };

        Because of = () => answer = AreaFinder.Calculate(input);

        It Should_Return_An_Integer_Area = () => answer.ShouldEqual(expect);

        static List<int[]> input;
        static int expect;
        private static long answer;
    }

    public class When_Trying_Without_Rectangles
    {
        Establish context = () =>
        {
            input = new List<int[]>
            {

            };
            expect = 0;
        };

        Because of = () => answer = AreaFinder.Calculate(input);

        It Should_Return_An_Integer_Area = () => answer.ShouldEqual(expect);

        private static IEnumerable<int[]> input;
        private static int expect;
        private static long answer;

    }

    public class When_Generating_Many_Random_Rectangles
    {
        Establish context = () =>
        {
            input = 10;
        };

        Because of = () => answer = AreaFinder.GenerateRandomRectangles(input);

        It Should_Return_Expected_Number_Of_Rectangles = () => answer.Count.ShouldEqual(input);

        static int input;
        static List<int[]> answer;
    }

    public class When_Generating_Many_Planned_Rectangles
    {
        Establish context = () =>
        {
            input = 11;
            expect = new List<int[]>
            {
                new int[]{0,0,10,10},
                new int[]{1,1,11,11},
                new int[]{2,2,12,12},
                new int[]{3,3,13,13},
                new int[]{4,4,14,14 },
                new int[]{5,5,15,15},
                new int[]{6,6,16,16},
                new int[]{7,7,17,17},
                new int[]{8,8,18,18},
                new int[]{9,9,19,19},
                new int[]{10,10,20,20},
            };
        };

        Because of = () => answer = AreaFinder.GenerateOverlappingRectangles(input);

        It Should_Return_Expected_Number_Of_Rectangles = () => answer.Count.ShouldEqual(input);
        It Should_Return_Expected_Rectangles = () =>
        {
            for (var i = 0; i < answer.Count; i++)
            {
                for (var j = 0; j < answer[i].Length; j++)
                {
                    answer[i][j].ShouldEqual(expect[i][j]);
                }
            }
        };

        static int input;
        private static List<int[]> expect;
        static List<int[]> answer;
    }

    public class When_Trying_So_So_Many_Rectangles
    {
        Establish context = () =>
        {
            input = AreaFinder.GenerateRandomRectangles(15000);
            timeLimit = 12000;
        };

        Because of = () =>
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            answer = AreaFinder.Calculate(input);
            stopwatch.Stop();
            elapsedTime = stopwatch.ElapsedMilliseconds;
        };

        It Should_Have_Greater_Than_Zero_Area = () => answer.ShouldBeGreaterThan(0);
        It Should_Return_Faster_Than_12000_MS = () => elapsedTime.ShouldBeLessThanOrEqualTo(12000);
        It Should_Return_Faster_Than_11000_MS = () => elapsedTime.ShouldBeLessThanOrEqualTo(11000);
        It Should_Return_Faster_Than_10000_MS = () => elapsedTime.ShouldBeLessThanOrEqualTo(10000);
        It Should_Return_Faster_Than_9000_MS = () => elapsedTime.ShouldBeLessThanOrEqualTo(9000);
        It Should_Return_Faster_Than_8000_MS = () => elapsedTime.ShouldBeLessThanOrEqualTo(8000);
        It Should_Return_Faster_Than_7000_MS = () => elapsedTime.ShouldBeLessThanOrEqualTo(7000);
        It Should_Return_Faster_Than_6000_MS = () => elapsedTime.ShouldBeLessThanOrEqualTo(6000);
        It Should_Return_Faster_Than_5000_MS = () => elapsedTime.ShouldBeLessThanOrEqualTo(5000);
        It Should_Return_Faster_Than_4000_MS = () => elapsedTime.ShouldBeLessThanOrEqualTo(4000);

        static List<int[]> input;
        private static int timeLimit;
        static Stopwatch stopwatch;
        static long answer;
        static long elapsedTime;
    }

    public class When_Accounting_For_Rectangles_Covered_Completely_By_Other_Rectangles
    {
        Establish context = () =>
        {
            input = new List<int[]>
            {
                new int[]{0,0,10,10},
                new int[]{1,1,9,9},
                new int[]{0,5,11,10}
            };
            expect = 105;
        };

        Because of = () => answer = AreaFinder.Calculate(input);

        It Should_Return_Expected_Area = () => answer.ShouldEqual(expect);

        private static List<int[]> input;
        private static int expect;
        private static long answer;
    }

    public class When_Solving_For_An_Edge_Case
    {
        Establish context = () =>
        {
            input = new List<int[]>
            {
                new int[]{3,3,8,5},
                new int[]{6,3,8,9},
                new int[]{11,6,14,12}
            };
            expect = 36;
        };

        Because of = () => answer = AreaFinder.Calculate(input);

        It Should_Be_What_Was_Expected = () => answer.ShouldEqual(expect);

        private static List<int[]> input;
        private static long expect;
        private static long answer;
    }

    public class When_Passing_In_Flat_Rectangles
    {
        Establish context = () =>
        {
            input = new List<int[]>
            {
                new int[]{3,3,3,5},
                new int[]{6,2,11,2},
                new int[]{5,5,6,6}
            };
            expect = 1;
        };

        Because of = () => answer = AreaFinder.Calculate(input);

        It Should_Be_What_Was_Expected = () => answer.ShouldEqual(expect);

        private static List<int[]> input;
        private static long expect;
        private static long answer;
    }

    //public class When_Removing_Covered_Rectangles
    //{
    //    Establish context = () =>
    //    {
    //        input = new List<int[]>
    //        {
    //            new int[]{3,3,12,12},
    //            new int[]{4,4,11,11},
    //            new int[]{5,5,6,13}
    //        };
    //        expect = new List<int[]>
    //        {
    //            new int[]{3,3,12,12},
    //            new int[]{5,5,6,13}
    //        };
    //    };

    //    Because of = () => ans = AreaFinder.FindCoveredRectangles(input).OrderBy(rectangle => rectangle[0]).ToList();

    //    It Should_Have_Removed_Rectangles_Without_An_Outer_Edge = () =>
    //    {
    //        var answer = ans.OrderBy(rectangle => rectangle[0]).ToList();
    //        for (var i = 0; i < answer.Count; i++)
    //        {
    //            for (var j = 0; j < answer[i].Length; j++)
    //            {
    //                answer[i][j].ShouldEqual(expect[i][j]);
    //            }
    //        }
    //    };

    //    private static List<int[]> input;
    //    private static List<int[]> expect;
    //    private static List<int[]> answer;
    //    private static List<int[]> ans;
    //}

    public class When_Building_A_Polygon_From_Rectangles_Including_Gaps
    {
        Establish context = () =>
        {
            input = new List<int[]>
            {
                new int[] {0,0,10,10},
                new int[] {5,5,15,15},
                new int[] {6,20,8,25}
            };
            expect = new Dictionary<int, List<(int, int)>>
            {
                { 1, new List<(int, int)>{ (0,10) } },
                { 2, new List<(int, int)>{ (0,10) } },
                { 3, new List<(int, int)>{ (0,10)} },
                { 4, new List<(int, int)>{ (0,10)} },
                { 5, new List<(int, int)>{ (0,10)} },
                { 6, new List<(int, int)>{ (0,15) } },
                { 7, new List<(int, int)>{ (0,15), (20,25) } },
                { 8, new List<(int, int)>{ (0, 15), (20, 25) } },
                { 9, new List<(int, int)>{ (0,15) } },
                { 10, new List<(int, int)>{ (0,15) } },
                { 11, new List<(int, int)>{ (5,15) } },
                { 12, new List<(int, int)>{ (5,15) } },
                { 13, new List<(int, int)>{ (5,15) } },
                { 14, new List<(int, int)>{ (5,15) } },
                { 15, new List<(int, int)>{ (5,15) } }
            };
        };

        Because of = () => answer = AreaFinder.BuildPolygon(input);

        It Should_Return_The_Perimiter_Of_A_Polygon = () =>
        {
            for (var i = expect.Keys.Min(); i < expect.Count; i++)
            {
                for (var j = 0; j < expect[i].Count; j++)
                {
                    if (answer[i][j] != expect[i][j])
                    {
                        var answ = answer[i][j];
                        var exp = expect[i][j];
                    }
                    answer[i][j].ShouldEqual(expect[i][j]);
                }
            }
        };

        private static List<int[]> input;
        private static Dictionary<int,List<(int, int)>> expect;
        private static Dictionary<int, List<(int, int)>> answer;
    }

    public class When_Building_A_Polygon_From_Tons_Of_Rectangles
    {
        Establish context = () =>
        {
            input = AreaFinder.GenerateOverlappingRectangles(10);
            expect = new Dictionary<int, List<(int, int)>>
            {
                { 1, new List<(int, int)>{ (0,10) } },
                { 2, new List<(int, int)>{ (0,11) } },
                { 3, new List<(int, int)>{ (0,12)} },
                { 4, new List<(int, int)>{ (0,13)} },
                { 5, new List<(int, int)>{ (0,14)} },
                { 6, new List<(int, int)>{ (0,15) } },
                { 7, new List<(int, int)>{ (0,16) } },
                { 8, new List<(int, int)>{ (0,17) } },
                { 9, new List<(int, int)>{ (0,18) } },
                { 10, new List<(int, int)>{ (0,19) } },
                { 11, new List<(int, int)>{ (1,19) } },
                { 12, new List<(int, int)>{ (2,19) } },
                { 13, new List<(int, int)>{ (3,19) } },
                { 14, new List<(int, int)>{ (4,19) } },
                { 15, new List<(int, int)>{ (5,19) } },
                { 16, new List<(int, int)>{ (6,19) } },
                {17, new List<(int, int)>{ (7,19) } },
                {18, new List<(int, int)>{ (8,19) } },
                {19, new List<(int, int)>{ (9,19) } },
                {20, new List<(int, int)>{ (10,19) } },
            };
        };

        Because of = () => answer = AreaFinder.BuildPolygon(input);

        It Should_Return_The_Perimiter_Of_A_Polygon = () =>
        {
            for (var i = expect.Keys.Min(); i < expect.Count; i++)
            {
                for (var j = 0; j < expect[i].Count; j++)
                {
                    if (answer[i][j] != expect[i][j])
                    {
                        var answ = answer[i][j];
                        var exp = expect[i][j];
                    }
                    answer[i][j].ShouldEqual(expect[i][j]);
                }
            }
        };

        private static List<int[]> input;
        private static Dictionary<int, List<(int, int)>> expect;
        private static Dictionary<int, List<(int, int)>> answer;
    }

    public class When_Generating_Many_Rectangles_With_Gaps
    {
        Establish context = () =>
        {
            input = 11;
        };

        Because of = () => answer = AreaFinder.GenerateRectanglesWithGaps(input);

        It Should_Return_Expected_Number_Of_Rectangles = () => answer.Count.ShouldEqual(input);

        static int input;
        static List<int[]> answer;
    }

    public class When_Finding_Area_Of_Polygon
    {
        Establish context = () =>
        {
            input = new List<(int, int)>
            {
                (0,10),
                (0,10),
                (0,10),
                (0,10),
                (0,10),
                (0,15),
                (0,15),
                (20,25),
                (0,15),
                (20,25),
                (0,15),
                (0,15),
                (5,15),
                (5,15),
                (5,15),
                (5,15),
                (5,15)
            };
            expect = 185;
        };

        Because of = () => answer = AreaFinder.FindAreaOfPolygon(input);

        It Should_Return_The_Area_Of_The_Polygon = () => answer.ShouldEqual(expect);

        private static List<(int, int)> input;
        private static int expect;
        private static long answer;
    }
}