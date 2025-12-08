using AdventOfCode.Solutions.Year2025;

namespace AdventOfCode.Tests.Year2025;

public class Day02Tests
{
    private readonly Day02 _problem = new();

    [Theory]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124", "1227775554")]
    public void SolvePart1(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("11-22", new long[] { 11, 22 })]
    [InlineData("95-115", new long[] { 99 })]
    [InlineData("998-1012", new long[] { 1010 })]
    [InlineData("1188511880-1188511890", new long[] { 1188511885 })]
    [InlineData("222220-222224", new long[] { 222222 })]
    public void GetArryOfInvalidIdsPart1(string input, long[] invalidIds)
    {
        var result = Day02.GetArrayOfInvalidIdsPart1(input);
        Assert.Equal(invalidIds, result);
    }

    [Theory]
    [InlineData("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124", "4174379265")]
    public void SolvePart2(string input, string expected)
    {
        var result = _problem.SolvePart2(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("11-22", new long[] { 11, 22 })]
    [InlineData("95-115", new long[] { 99, 111 })]
    [InlineData("998-1012", new long[] { 999, 1010 })]
    [InlineData("1188511880-1188511890", new long[] { 1188511885 })]
    [InlineData("222220-222224", new long[] { 222222 })]
    public void GetArryOfInvalidIdsPart2(string input, long[] invalidIds)
    {
        var result = Day02.GetArrayOfInvalidIdsPart2(input);
        Assert.Equal(invalidIds, result);
    }
}
