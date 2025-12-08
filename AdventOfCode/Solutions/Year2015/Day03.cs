using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2015;

public class Day03 : ISolution
{
    public string SolvePart1(string input)
    {
        var inputs = ParseInput(input);
        (int, int) currentLocation = (0, 0);
        var visitedLocations = new HashSet<(int, int)>
        {
            currentLocation
        };

        foreach(var direction in inputs)
        {
            switch (direction)
            {
                case '^':
                    currentLocation.Item2 += 1;
                    break;
                case 'v':
                    currentLocation.Item2 -= 1;
                    break;
                case '>':
                    currentLocation.Item1 += 1;
                    break;
                case '<':
                    currentLocation.Item1 -= 1;
                    break;
            }
            visitedLocations.Add(currentLocation);
        }

        return visitedLocations.Count.ToString();
    }

    public string SolvePart2(string input)
    {
        var inputs = ParseInput(input);
        (int, int) santaLocation = (0, 0);
        (int, int) roboLocation = (0, 0);
        var visitedLocations = new HashSet<(int, int)>
        {
            santaLocation
        };

        for (int i = 0; i< inputs.Length; i++)
        {
            var direction = inputs[i];
            var currentLocation = i % 2 == 0 ? santaLocation : roboLocation;
            switch (direction)
            {
                case '^':
                    currentLocation.Item2 += 1;
                    break;
                case 'v':
                    currentLocation.Item2 -= 1;
                    break;
                case '>':
                    currentLocation.Item1 += 1;
                    break;
                case '<':
                    currentLocation.Item1 -= 1;
                    break;
            }
            if (i % 2 == 0)
                santaLocation = currentLocation;
            else
                roboLocation = currentLocation;
            visitedLocations.Add(currentLocation);
        }

        return visitedLocations.Count.ToString();
    }

    private static char[] ParseInput(string input)
    {
        return input.ToCharArray();
    }

    private class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
