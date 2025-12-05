using AdventOfCode.Solutions.Year2015;

namespace AdventOfCode.Tests.Year2015;

public class Day04Tests
{
    private readonly Day04 _problem = new();

    [Theory]
    [InlineData("abcdef", "609043")]
    [InlineData("pqrstuv", "1048970")]
    public void SolvePart1(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }
}
