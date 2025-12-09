using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2025;

public class Day07 : ISolution
{
    public string SolvePart1(string input)
    {
        var charArray = InputParser.ToCharGrid(input);
        int totalSplits = 0;

        for (int y = 1; y < charArray.GetLength(1); y++)
        {
            for (int x = 0; x < charArray.GetLength(0); x++)
            {
                if (charArray[x, y - 1] == 'S')
                {
                    charArray[x, y] = '|';
                }
                if (charArray[x, y - 1] == '|')
                {
                    if (charArray[x, y] == '.')
                    {
                        charArray[x, y] = '|';
                    }
                    if (charArray[x, y] == '^')
                    {
                        totalSplits++;
                        charArray[x-1, y] = '|';
                        charArray[x+1, y] = '|';
                    }
                }
            }
        }

        return totalSplits.ToString();
    }

    public string SolvePart2(string input)
    {
        var charArray = InputParser.ToCharGrid(input);
        return GetTimelines(charArray, 0, 0, "").ToString();
    }

    private Dictionary<(int, int), long> cache = new Dictionary<(int X, int Y), long>();


    private long GetTimelines(char[,] charArray, int startX, int startY, string path)
    {
        if (cache.TryGetValue((X: startX, Y: startY), out var value))
        {
            return value;
        }

        for (int y = startY; y < charArray.GetLength(1); y++)
        {
            for (int x = startX; x < charArray.GetLength(0); x++)
            {
                if (charArray[x, y] == 'S')
                {
                    charArray[x, y+1] = '|';
                }
                if (charArray[x, y] == '|')
                {
                    if (y == charArray.GetLength(1) - 1)
                    {
                        return 1;
                    }
                    if (charArray[x, y+1] == '.')
                    {
                        charArray[x, y+1] = '|';
                    }
                    if (charArray[x, y+1] == '^')
                    {
                        var leftArray = charArray.DeepCopy();
                        var rightArray = charArray.DeepCopy();
                        leftArray[x - 1, y + 1] = '|';
                        rightArray[x + 1, y + 1] = '|';

                        var left = GetTimelines(leftArray, x - 1, y + 1, path + "L");
                        var right = GetTimelines(rightArray, x + 1, y + 1, path + "R");
                        var leftKey = (X: x - 1, Y: y + 1);
                        cache[leftKey] = left;
                        var rightKey = (X: x + 1, Y: y + 1);
                        cache[rightKey] = right;

                        return left + right;
                    }
                }
            }
        }
        return 0;
    }
}