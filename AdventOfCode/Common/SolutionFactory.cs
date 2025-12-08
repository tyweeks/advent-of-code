using System.Reflection;

namespace AdventOfCode.Common;

public static class SolutionFactory
{
    public static ISolution GetSolution(int year, int day)
    {
        string typeName = $"AdventOfCode.Solutions.Year{year}.Day{day:00}";

        var assembly = Assembly.GetExecutingAssembly();
        var type = assembly.GetType(typeName);

        if (type is null || !typeof(ISolution).IsAssignableFrom(type))
            throw new ArgumentException($"Solution for {year} Day {day:00} not found.");

        return (ISolution)Activator.CreateInstance(type)!;
    }

    public static string GetInput(int yearNumber, int dayNumber)
    {
        var inputPath = Path.Combine("Inputs", $"Year{yearNumber:D4}", $"day{dayNumber:D2}.txt");
        if (!File.Exists(inputPath))
        {
            throw new FileNotFoundException($"Input file for day {dayNumber} not found at {inputPath}");
        }
        return File.ReadAllText(inputPath);
    }
}
