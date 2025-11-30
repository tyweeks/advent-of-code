using AdventOfCode2025.Common;

namespace AdventOfCode2025.Days;

public class Day00 : IProblem
{
    public string SolvePart1(string input)
    {
        var numbers = ParseNumbers(input);
        return numbers.Sum().ToString();
    }

    public string SolvePart2(string input)
    {
        var numbers = ParseNumbers(input);
        return numbers.Aggregate(1L, (acc, n) => acc * n).ToString();
    }

    private static List<int> ParseNumbers(string input)
    {
        return input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => int.Parse(line.Trim()))
            .ToList();
    }
}