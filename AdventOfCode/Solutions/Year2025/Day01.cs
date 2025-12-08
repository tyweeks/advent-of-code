using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2025;

public class Day01 : ISolution
{
    public string SolvePart1(string input)
    {
        var inputs = ParseInput(input);
        int currentNum = 50;
        int zeroCounter = 0;

        foreach (var line in inputs)
        {
            var direction = line[0];
            var value = int.Parse(line[1..]);
            if (direction == 'L')
            {
                currentNum -= value;
            }
            else if (direction == 'R')
            {
                currentNum += value;
            }
            else
            {
                throw new Exception("Invalid direction");
            }

            currentNum = ((currentNum % 100) + 100) % 100;

            if (currentNum == 0)
            {
                zeroCounter++;
            }
        }

        return zeroCounter.ToString();
    }

    public string SolvePart2(string input)
    {
        var inputs = ParseInput(input);
        int currentNum = 50;
        int zeroCounter = 0;

        foreach (var line in inputs)
        {
            int startingNum = currentNum;
            var direction = line[0];
            var value = int.Parse(line[1..]);
            for (int i = 0; i < value; i++)
            {
                if (direction == 'L')
                {
                    currentNum -= 1;
                }
                else if (direction == 'R')
                {
                    currentNum += 1;
                }
                else
                {
                    throw new Exception("Invalid direction");
                }

                currentNum = ((currentNum % 100) + 100) % 100;

                if (currentNum == 0)
                {
                    zeroCounter++;
                }
            }
        }

        return zeroCounter.ToString();
    }

    private static List<string> ParseInput(string input)
    {
        return input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .ToList();
    }
}