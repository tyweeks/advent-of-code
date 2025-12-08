using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2025;

public class Day03 : ISolution
{
    public string SolvePart1(string input)
    {
        var inputs = ParseInput(input);
        long sum = 0;

        foreach (var bank in inputs)
        {
            sum += long.Parse(GetLargestJoltage(bank.ToCharArray(), 2));
        }

        return sum.ToString();
    }

    public static string GetLargestJoltage(char[] input, int batteries)
    {
        if (batteries == 0)
            return "";

        var maxJoltage = 0;
        var maxIndex = 0;

        for (int i = 0; i <= input.Length - batteries; i++)
        {
            var joltage = int.Parse(input[i].ToString());
            if (joltage > maxJoltage)
            {
                maxJoltage = joltage;
                maxIndex = i;
            }
        }

        var maxString = input[maxIndex].ToString();
        return maxString + GetLargestJoltage(input[(maxIndex+1)..], batteries-1);
    }

    public string SolvePart2(string input)
    {
        var inputs = ParseInput(input);
        long sum = 0;

        foreach (var bank in inputs)
        {
            sum += long.Parse(GetLargestJoltage(bank.ToCharArray(), 12));
        }

        return sum.ToString();
    }

    private static List<string> ParseInput(string input)
    {
        return input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .ToList();
    }
}