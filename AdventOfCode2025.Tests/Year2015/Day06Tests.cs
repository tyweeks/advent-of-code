using AdventOfCode.Solutions.Year2015;

namespace AdventOfCode.Tests.Year2015;

public class Day06Tests
{
    private readonly Day06 _problem = new();

    [Theory]
    [InlineData("", "0")]
    [InlineData("turn on 0,0 through 4,4", "25")]
    [InlineData("turn on 0,0 through 4,4\r\ntoggle 1,1 through 3,3\r\nturn off 0,0 through 4,0", "11")]
    public void SolvePart1(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("turn on 0,0 through 0,0", "1")]
    [InlineData("turn off 0,0 through 0,0", "0")]
    [InlineData("toggle 0,0 through 999,999", "2000000")]
    public void SolvePart2(string input, string expected)
    {
        var result = _problem.SolvePart2(input);
        Assert.Equal(expected, result);
    }
}
