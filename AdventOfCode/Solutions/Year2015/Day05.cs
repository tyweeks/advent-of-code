using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2015;

public class Day05 : ISolution
{
    public string SolvePart1(string input)
    {
        var inputs = ParseInput(input);
        var numNice = 0;

        foreach (var x in inputs)
        {
            numNice += IsNicePart1(x) ? 1 : 0;
        }

        return numNice.ToString();
    }

    public bool IsNicePart1(string input)
    {
        int vowelCount = 0;
        bool hasDoubleLetter = false;
        bool hasForbiddenSubstring = false;

        var forbiddenSubstrings = new[] { "ab", "cd", "pq", "xy" };

        var chars = input.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            char c = chars[i];
            // Check for vowels
            if ("aeiou".Contains(c))
            {
                vowelCount++;
            }
            // Check for double letters
            if (i > 0 && chars[i] == chars[i - 1])
            {
                hasDoubleLetter = true;
            }
            // Check for forbidden substrings
            if (i > 0)
            {
                string pair = $"{chars[i - 1]}{chars[i]}";
                if (forbiddenSubstrings.Contains(pair))
                {
                    hasForbiddenSubstring = true;
                }
            }
        }

        return vowelCount >= 3 && hasDoubleLetter && !hasForbiddenSubstring;
    }

    public bool IsNicePart2(string input)
    {
        bool hasRepeatingPair = false;
        bool hasRepeatingLettingWithCharBetween = false;

        var forbiddenSubstrings = new[] { "ab", "cd", "pq", "xy" };

        var chars = input.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            char c = chars[i];
            // Check for repeating letter with one letter between
            if (i > 1 && chars[i] == chars[i - 2])
            {
                hasRepeatingLettingWithCharBetween = true;
            }
            // Check for repeating pair
            if (i > 0)
            {
                string pair = $"{chars[i - 1]}{chars[i]}";
                for (int j = i + 2; j < chars.Length; j++)
                {
                    string newPair = $"{chars[j - 1]}{chars[j]}";
                    if (pair == newPair)
                    {
                        hasRepeatingPair = true;
                        break;
                    }
                }
            }
        }

        return hasRepeatingPair && hasRepeatingLettingWithCharBetween;
    }

    public string SolvePart2(string input)
    {
        var inputs = ParseInput(input);
        var numNice = 0;

        foreach (var x in inputs)
        {
            numNice += IsNicePart2(x) ? 1 : 0;
        }

        return numNice.ToString();
    }

    private static List<string> ParseInput(string input)
    {
        return input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .ToList();
    }
}
