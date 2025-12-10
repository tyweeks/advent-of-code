using AdventOfCode.Solutions.Year2019;

namespace AdventOfCode.Tests.Year2019;

public class Day01Tests
{
    private readonly Day01 _problem = new();

    [Theory]
    [InlineData("12", "2")]
    [InlineData("14", "2")]
    [InlineData("1969", "654")]
    [InlineData("100756", "33583")]
    [InlineData("12\r\n14\r\n1969\r\n100756", "34241")]
    public void SolvePart1(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("14", "2")]
    [InlineData("1969", "966")]
    [InlineData("100756", "50346")]
    public void SolvePart2(string input, string expected)
    {
        var result = _problem.SolvePart2(input);
        Assert.Equal(expected, result);
    }
}
