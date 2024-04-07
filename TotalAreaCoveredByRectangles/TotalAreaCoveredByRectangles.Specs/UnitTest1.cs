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

    public class When_Generating_Many_Rectangles
    {
        Establish context = () =>
        {
            input = 10;
        };

        Because of = () => answer = AreaFinder.GenerateRectangles(input);

        It Should_Return_Expected_Number_Of_Rectangles = () => answer.Count.ShouldEqual(input);

        static int input;
        static List<int[]> answer;
    }

    public class When_Trying_So_So_Many_Rectangles
    {
        Establish context = () =>
        {
            input = AreaFinder.GenerateRectangles(15000);
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

    public class When_Building_A_Polygon_From_Rectangles
    {
        Establish context = () =>
        {
            input = new List<int[]>
            {
                new int[] {0,0,10,10},
                new int[] {5,5,15,15},
                new int[] {6,20,8,25}
            };
            expect = new List<List<(int, int)>>
            {
                new List<(int, int)>
                {
                    (0,10)
                },
                new List<(int, int)>
                {
                    (0,10)
                },
                new List<(int, int)>
                {
                    (0,10)
                },
                new List<(int, int)>
                {
                    (0,10)
                },
                new List<(int, int)>
                {
                    (0,10)
                },
                new List<(int, int)>
                {
                    (0,15)
                },
                new List<(int, int)>
                {
                    (0,15),
                    (20,25)
                },
                new List<(int, int)>
                {
                    (0,15),
                    (20,25)
                },
                new List<(int, int)>
                {
                    (0,15),
                    (20,25)
                },
                new List<(int, int)>
                {
                    (0,10)
                },
                new List<(int, int)>
                {
                    (0,10)
                },
                new List<(int, int)>
                {
                    (5,15)
                },
                new List<(int, int)>
                {
                    (5,15)
                },
                new List<(int, int)>
                {
                    (5,15)
                },
                new List<(int, int)>
                {
                    (5,15)
                },
                new List<(int, int)>
                {
                    (5,15)
                },
            };
        };

        Because of = () => answer = AreaFinder.FindCoveredRectangles(input);

        It Should_Return_The_Primiter_Of_A_Polygon = () =>
        {
            for(var i=0; i< expect.Count; i++)
            {
                for(var j=0; j < expect[i].Count; j++)
                {
                    answer[i][j].ShouldEqual(expect[i][j]);
                }
            }
        };

        private static List<int[]> input;
        private static List<List<(int, int)>> expect;
        private static List<List<(int, int)>> answer;
    }
}