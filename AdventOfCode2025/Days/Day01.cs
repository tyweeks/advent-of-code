using AdventOfCode2025.Common;

namespace AdventOfCode2025.Days;

public class Day01 : IProblem
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

            while (currentNum < 0)
            {
                currentNum += 100;
            }

            while (currentNum > 99)
            {
                currentNum -= 100;
            }

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

            while (currentNum < 0)
            {
                currentNum += 100;
                zeroCounter++;
            }

            while (currentNum > 99)
            {
                currentNum -= 100;
                zeroCounter++;
            }

            if (currentNum == 0 && direction == 'L')
            {
                zeroCounter++;
            }

            if (startingNum == 0 && direction == 'L')
            {
                zeroCounter--;
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