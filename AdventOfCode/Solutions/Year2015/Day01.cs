using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2015;

public class Day01 : ISolution
{
    public string SolvePart1(string input)
    {
        var inputs = ParseInput(input);
        var currentFloor = 0;

        foreach (var x in inputs)
        {
            if (x == '(')
            {
                currentFloor++;
            }
            else if (x == ')')
            {
                currentFloor--;
            }
            else
            {
                throw new Exception("Invalid character");
            }
        }

        return currentFloor.ToString();
    }

    public string SolvePart2(string input)
    {
        var inputs = ParseInput(input);
        var currentFloor = 0;

        for (int i = 1; i <= inputs.Length; i++)
        {
            var x = inputs[i - 1];
            if (x == '(')
            {
                currentFloor++;
            }
            else if (x == ')')
            {
                currentFloor--;
            }
            else
            {
                throw new Exception("Invalid character");
            }

            if (currentFloor == -1)
            {
                return i.ToString();
            }
        }

        return "";
    }

    private static char[] ParseInput(string input)
    {
        return input.ToCharArray();
    }
}
