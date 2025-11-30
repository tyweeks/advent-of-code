using AdventOfCode2025.Days;

namespace AdventOfCode2025.Common;

public static class ProblemFactory
{
    public static IProblem Get(int dayNumber)
    {
        return dayNumber switch
        {
            0 => new Day00(),
            _ => throw new ArgumentException($"Problem for day {dayNumber} not found", nameof(dayNumber))
        };
    }

    public static string GetInput(int dayNumber)
    {
        var inputPath = Path.Combine("Inputs", $"day{dayNumber:D2}.txt");
        if (!File.Exists(inputPath))
        {
            throw new FileNotFoundException($"Input file for day {dayNumber} not found at {inputPath}");
        }
        return File.ReadAllText(inputPath);
    }
}
