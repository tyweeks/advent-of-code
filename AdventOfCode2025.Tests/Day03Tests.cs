using AdventOfCode2025.Days;

namespace AdventOfCode2025.Tests;

public class Day03Tests
{
    private readonly Day03 _problem = new();

    [Theory]
    [InlineData("", "")]
    public void SolvePart1(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", "")]
    public void SolvePart2(string input, string expected)
    {
        var result = _problem.SolvePart2(input);
        Assert.Equal(expected, result);
    }
}
