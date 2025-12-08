using AdventOfCode.Solutions.Year2025;

namespace AdventOfCode.Tests.Year2025;

public class Day03Tests
{
    private readonly Day03 _problem = new();

    [Theory]
    [InlineData("987654321111111\r\n811111111111119\r\n234234234234278\r\n818181911112111", "357")]
    public void SolvePart1(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("987654321111111", 2, "98")]
    [InlineData("811111111111119", 2, "89")]
    [InlineData("234234234234278", 2, "78")]
    [InlineData("818181911112111", 2, "92")]
    [InlineData("987654321111111", 12, "987654321111")]
    [InlineData("811111111111119", 12, "811111111119")]
    [InlineData("234234234234278", 12, "434234234278")]
    [InlineData("818181911112111", 12, "888911112111")]
    public void GetLargestJoltage(string input, int numBatteries, string largestJoltage)
    {
        var result = Day03.GetLargestJoltage(input.ToCharArray(), numBatteries);
        Assert.Equal(largestJoltage, result);
    }

    [Theory]
    [InlineData("987654321111111\r\n811111111111119\r\n234234234234278\r\n818181911112111", "3121910778619")]
    public void SolvePart2(string input, string expected)
    {
        var result = _problem.SolvePart2(input);
        Assert.Equal(expected, result);
    }
}
