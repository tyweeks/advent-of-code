using AdventOfCode.Solutions.Year2025;

namespace AdventOfCode.Tests.Year2025;

public class Day06Tests
{
    private readonly Day06 _problem = new();

    [Theory]
    [InlineData("123 328  51 64 \r\n 45 64  387 23 \r\n  6 98  215 314\r\n*   +   *   +  ", "4277556")]
    public void SolvePart1(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123 328  51 64 \r\n 45 64  387 23 \r\n  6 98  215 314\r\n*   +   *   +  ", "3263827")]
    public void SolvePart2(string input, string expected)
    {
        var result = _problem.SolvePart2(input);
        Assert.Equal(expected, result);
    }
}
