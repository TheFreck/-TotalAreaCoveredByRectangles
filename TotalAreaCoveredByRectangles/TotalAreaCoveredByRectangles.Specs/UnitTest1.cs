using Machine.Specifications;
using System.Collections;

namespace TotalAreaCoveredByRectangles.Specs
{
    public class When_Finding_The_Area_Of_Rectangles
    {
        Establish context = () =>
        {
            input = new List<int[]>
            {
                new [] {0, 4, 11, 6}
            };
            expect = 22;
        };

        Because of = () => answer = AreaFinder.Calculate(input);

        It Should_Return_An_Integer_Area = () => answer.ShouldEqual(expect);

        private static IEnumerable<int[]> input;
        private static int expect;
        private static long answer;
    }
}