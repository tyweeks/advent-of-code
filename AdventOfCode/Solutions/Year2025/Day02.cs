using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2025;

public class Day02 : ISolution
{
    public string SolvePart1(string input)
    {
        var inputs = ParseInput(input);
        long totalInvalidIds = 0;

        foreach (var range in inputs)
        {
            var invalidIds = GetArrayOfInvalidIdsPart1(range);
            foreach(var id in invalidIds)
            {
                totalInvalidIds += id;
            }
        }

        return totalInvalidIds.ToString();
    }

    public static long[] GetArrayOfInvalidIdsPart1(string input)
    {
        List<long> invalidIds = new();
        var startingId = long.Parse(input.Split('-')[0]);
        var endingId = long.Parse(input.Split('-')[1]);

        for (long i = startingId; i <= endingId; i++)
        {
            var id = i.ToString();
            if (id.Length % 2 != 0)
                continue;
            var mid = id.Length / 2;
            if (id.Substring(0, mid) == id.Substring(mid, mid))
            {
                invalidIds.Add(i);
            }
        }

        return invalidIds.ToArray();
    }

    public string SolvePart2(string input)
    {
        var inputs = ParseInput(input);
        long totalInvalidIds = 0;

        foreach (var range in inputs)
        {
            var invalidIds = GetArrayOfInvalidIdsPart2(range);
            foreach (var id in invalidIds)
            {
                totalInvalidIds += id;
            }
        }

        return totalInvalidIds.ToString();
    }

    public static long[] GetArrayOfInvalidIdsPart2(string input)
    {
        List<long> invalidIds = new();
        var startingId = long.Parse(input.Split('-')[0]);
        var endingId = long.Parse(input.Split('-')[1]);

        for (long i = startingId; i <= endingId; i++)
        {
            var id = i.ToString();

            for (int j = 2; j < 10; j++)
            {
                if (id.Length % j != 0)
                    continue;
                var segmentLength = id.Length / j;
                bool allSegmentsEqual = true;
                var firstSegment = id.Substring(0, segmentLength);
                for (int k = 1; k < j; k++)
                {
                    if (id.Substring(k * segmentLength, segmentLength) != firstSegment)
                    {
                        allSegmentsEqual = false;
                        break;
                    }
                }
                if (allSegmentsEqual)
                {
                    invalidIds.Add(i);
                    break;
                }
            }
        }

        return invalidIds.ToArray();
    }

    private static List<string> ParseInput(string input)
    {
        return input
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .ToList();
    }
}