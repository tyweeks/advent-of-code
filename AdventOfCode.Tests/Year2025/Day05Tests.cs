using AdventOfCode.Solutions.Year2025;

namespace AdventOfCode.Tests.Year2025;

public class Day05Tests
{
    private readonly Day05 _problem = new();

    [Theory]
    [InlineData("3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32", "3")]
    public void SolvePart1(string input, string expected)
    {
        var result = _problem.SolvePart1(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("3-5\r\n10-14\r\n16-20\r\n12-18", "14")]
    [InlineData("3-5\r\n10-14\r\n16-20\r\n12-18\r\n21-25", "19")]
    [InlineData("1-2\r\n2-3\r\n3-4\r\n4-5\r\n5-6", "6")]
    [InlineData("1-2\r\n1-3\r\n1-4\r\n1-5\r\n1-6", "6")]
    [InlineData("1-2\r\n2-3\r\n1-4\r\n1-5\r\n1-6\r\n4-8", "8")]
    [InlineData("1-2\r\n3-4\r\n5-6\r\n7-8\r\n9-10\r\n11-12", "12")]
    [InlineData("1-2\r\n3-4\r\n5-7\r\n7-8\r\n9-10\r\n11-12", "12")]
    [InlineData("10-11\r\n3-4\r\n5-7\r\n7-8\r\n9-10\r\n11-12", "10")]
    [InlineData("1-2\r\n3-3\r\n4-4\r\n7-8\r\n9-9\r\n9-10", "8")]
    [InlineData("1-10\r\n3-4", "10")]
    [InlineData("1-10\r\n3-4\r\n7-7", "10")]
    [InlineData("1-10\r\n3-4\r\n17-17", "11")]
    [InlineData("1-1\r\n1-4", "4")]
    [InlineData("1-1\r\n4-4", "2")]
    [InlineData("3-6\r\n1-3\r\n5-8", "8")]
    [InlineData("3-6\r\n1-10", "10")]
    public void SolvePart2(string input, string expected)
    {
        var result = _problem.SolvePart2(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32", new[] { "3-5", "10-14", "16-20", "12-18" })]
    public void GetFreshIdRanges(string input, string[] ranges)
    {
        var result = Day05.GetFreshIdRanges(input);
        Assert.Equal(ranges, result);
    }

    [Theory]
    [InlineData("3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32", new[] { "1", "5", "8", "11", "17", "32" })]
    public void GetIngredientIds(string input, string[] ingredientIds)
    {
        var result = Day05.GetIngredientIds(input);
        Assert.Equal(ingredientIds, result);
    }
}
