using AdventOfCode.Solutions.Year2015;

namespace AdventOfCode.Tests.Year2015;

public class Day05Tests
{
    private readonly Day05 _problem = new();

    [Theory]
    [InlineData("ugknbfddgicrmopn", true)]
    [InlineData("aaa", true)]
    [InlineData("jchzalrnumimnmhp", false)]
    [InlineData("haegwjzuvuyypxyu", false)]
    [InlineData("dvszwmarrgswjxmb", false)]
    public void SolvePart1(string input, bool expected)
    {
        var result = _problem.IsNicePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("qjhvhtzxzqqjkmpb", true)]
    [InlineData("xxyxx", true)]
    [InlineData("uurcxstgmygtbstg", false)]
    [InlineData("ieodomkazucvgmuy", false)]
    public void SolvePart2(string input, bool expected)
    {
        var result = _problem.IsNicePart2(input);
        Assert.Equal(expected, result);
    }
}
