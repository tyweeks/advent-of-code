using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2015;

public class Day02 : ISolution
{
    public string SolvePart1(string input)
    {
        var inputs = ParseInput(input);
        var paperNeeded = 0;

        foreach (var x in inputs)
        {
            var face1 = x.Length * x.Width;
            var face2 = x.Length * x.Height;
            var face3 = x.Width * x.Height;

            paperNeeded += 2 * face1 + 2 * face2 + 2 * face3 + Math.Min(Math.Min(face1, face2), face3);
        }

        return paperNeeded.ToString();
    }

    public string SolvePart2(string input)
    {
        var inputs = ParseInput(input);
        var ribbonNeeded = 0;

        foreach (var x in inputs)
        {
            var face1perimeter = 2 * x.Length + 2 * x.Width;
            var face2perimeter = 2 * x.Length + 2 * x.Height;
            var face3perimeter = 2* x.Width + 2 * x.Height;

            ribbonNeeded += Math.Min(Math.Min(face1perimeter, face2perimeter), face3perimeter) + (x.Length * x.Width * x.Height);
        }

        return ribbonNeeded.ToString();
    }

    private static List<BoxDimensions> ParseInput(string input)
    {
        return input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(dimensions => new BoxDimensions(dimensions))
            .ToList();
    }

    private class BoxDimensions
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public BoxDimensions(string dimensions)
        {
            Length = int.Parse(dimensions.Split('x')[0]);
            Width = int.Parse(dimensions.Split('x')[1]);
            Height = int.Parse(dimensions.Split('x')[2]);
        }
    }
}
