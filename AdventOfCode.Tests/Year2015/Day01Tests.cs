using AdventOfCode.Solutions.Year2015;

namespace AdventOfCode.Tests.Year2015;

public class Day01Tests
{
    private readonly Day01 _problem = new();

    [Theory]
    [InlineData("(())", "0")]
    [InlineData("()()", "0")]
    [InlineData("(((", "3")]
    [InlineData("(()(()(", "3")]
    [InlineData("))(((((", "3")]
    [InlineData("())", "-1")]
    [InlineData("))(", "-1")]
    [InlineData(")))", "-3")]
    [InlineData(")())())", "-3")]
    public void SolvePart1(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(")", "1")]
    [InlineData("()())", "5")]
    public void SolvePart2(string input, string expected)
    {
        var result = _problem.SolvePart2(input);
        Assert.Equal(expected, result);
    }
}
