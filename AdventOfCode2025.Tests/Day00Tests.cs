using AdventOfCode2025.Days;

namespace AdventOfCode2025.Tests;

public class Day00Tests
{
    private readonly Day00 _problem = new();

    [Theory]
    [InlineData("1\n2\n3", "6")]
    [InlineData("10\n20\n30", "60")]
    [InlineData("5", "5")]
    [InlineData("0\n0\n0", "0")]
    public void SolvePart1_WithNumbers_ReturnsSum(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2\n3", "6")]
    [InlineData("2\n3\n4", "24")]
    [InlineData("5", "5")]
    [InlineData("1\n1\n1", "1")]
    public void SolvePart2_WithNumbers_ReturnsProduct(string input, string expected)
    {
        var result = _problem.SolvePart2(input);
        Assert.Equal(expected, result);
    }
}
