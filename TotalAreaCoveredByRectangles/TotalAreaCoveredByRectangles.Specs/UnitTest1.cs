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

        static List<int[]> input;
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
}