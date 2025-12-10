using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2019;

public class Day01 : ISolution
{
    public string SolvePart1(string input)
    {
        var lines = InputParser.ToStringArray(input);

        List<int> masses = new List<int>();

        foreach (var line in lines)
        {
            masses.Add(int.Parse(line));
        }

        int sum = 0;
        foreach (var mass in masses)
        {
            sum += mass / 3 - 2;
        }

        return sum.ToString();
    }

    public string SolvePart2(string input)
    {
        var lines = InputParser.ToStringArray(input);

        List<int> masses = new List<int>();

        foreach (var line in lines)
        {
            masses.Add(int.Parse(line));
        }

        int sum = 0;
        foreach (var mass in masses)
        {
            sum += FuelCalculation(mass);
        }

        return sum.ToString();
    }

    public int FuelCalculation(int mass)
    {
        var newMass = mass / 3 - 2;
        if (newMass <= 0) return 0;

        return newMass + FuelCalculation(newMass);
    }
}