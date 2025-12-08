using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2025;

public class Day05 : ISolution
{
    public string SolvePart1(string input)
    {
        var freshIdRanges = GetFreshIdRanges(input);
        var ingredientIds = GetIngredientIds(input);
        var numFreshIngregients = 0;

        foreach (var ingredientId in ingredientIds)
        {
            if (IsIngredientInAnyFreshRange(long.Parse(ingredientId), freshIdRanges))
                numFreshIngregients++;
        }

        return numFreshIngregients.ToString();
    }

    public string SolvePart2(string input)
    {
        var freshIdRanges = GetFreshIdRangesAsRanges(input);
        var consolidatedRanges = new List<Range>();
        var consolidating = true;

        while (consolidating)
        {
            consolidating = false;
            foreach (var currentRange in freshIdRanges)
            {
                bool overlapsExistingRange = false;
                foreach (var existingRange in consolidatedRanges)
                {
                    if (currentRange.Start >= existingRange.Start && currentRange.Start <= existingRange.End && currentRange.End > existingRange.End)
                    {
                        existingRange.End = currentRange.End;
                        overlapsExistingRange = true;
                        break;
                    }
                    else if (currentRange.Start < existingRange.Start && currentRange.End >= existingRange.Start && currentRange.End <= existingRange.End)
                    {
                        existingRange.Start = currentRange.Start;
                        overlapsExistingRange = true;
                        break;
                    }
                    else if (currentRange.Start >= existingRange.Start && currentRange.End <= existingRange.End)
                    {
                        overlapsExistingRange = true;
                        break;
                    }
                    else if (currentRange.Start <= existingRange.Start && currentRange.End >= existingRange.End)
                    {
                        existingRange.Start = currentRange.Start;
                        existingRange.End = currentRange.End;
                        overlapsExistingRange = true;
                        break;
                    }
                }

                if (!overlapsExistingRange)
                    consolidatedRanges.Add(new Range() { Start = currentRange.Start, End = currentRange.End });
                else
                    consolidating = true;
            }

            freshIdRanges.Clear();
            foreach (var range in consolidatedRanges)
                freshIdRanges.Add(range);
            consolidatedRanges.Clear();
        }

        long sumFreshIds = 0;
        foreach (var range in freshIdRanges)
        {
            sumFreshIds += range.End - range.Start + 1;
        }

        return sumFreshIds.ToString();
    }

    public static List<string> GetFreshIdRanges(string input)
    {
        return input
            .Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)[0]
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .ToList();
    }

    private List<Range> GetFreshIdRangesAsRanges(string input)
    {
        var ranges = new List<Range>();
        var freshIdRanges = GetFreshIdRanges(input);

        foreach (var freshIdRange in freshIdRanges)
        {
            var newRange = new Range() { Start = long.Parse(freshIdRange.Split('-')[0]), End = long.Parse(freshIdRange.Split('-')[1]) };
            ranges.Add(newRange);
        }

        return ranges;
    }

    public static List<string> GetIngredientIds(string input)
    {
        return input
            .Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)[1]
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .ToList();
    }

    private bool IsIngredientInAnyFreshRange(long ingredientId, List<string> freshIdRanges)
    {
        foreach(var freshIdRange in  freshIdRanges)
        {
            if (IsIngredientInAFreshRange(ingredientId, freshIdRange))
                return true;
        }
        return false;
    }

    private bool IsIngredientInAFreshRange(long ingredientId, string freshIdRange)
    {
        var rangeStart = long.Parse(freshIdRange.Split('-')[0]);
        var rangeEnd = long.Parse(freshIdRange.Split('-')[1]);

        return ingredientId >= rangeStart && ingredientId <= rangeEnd;
    }

    private class Range
    {
        public long Start;
        public long End;
    }
}