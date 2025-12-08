using AdventOfCode.Solutions.Year2015;

namespace AdventOfCode.Tests.Year2015;

public class Day02Tests
{
    private readonly Day02 _problem = new();

    [Theory]
    [InlineData("2x3x4", "58")]
    [InlineData("1x1x10", "43")]
    public void SolvePart1(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("2x3x4", "34")]
    [InlineData("1x1x10", "14")]
    public void SolvePart2(string input, string expected)
    {
        var result = _problem.SolvePart2(input);
        Assert.Equal(expected, result);
    }
}
