using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2025;

public class Day06 : ISolution
{
    public string SolvePart1(string input)
    {
        var lines = GetLines(input);
        var numProblems = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        var problemArray = new Problem[numProblems];
        foreach (var line in lines)
        {
            for (int i = 0; i < numProblems; i++)
            {
                var x = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)[i];
                if (long.TryParse(x, out long result))
                {
                    if (problemArray[i] == null)
                        problemArray[i] = new Problem();
                    problemArray[i].Nums.Add(result);
                }
                else
                {
                    problemArray[i].Operation = char.Parse(x);
                }
            }
        }

        long total = 0;
        foreach(var problem in problemArray)
        {
            var result = problem.Nums[0];
            for (int i = 1; i < problem.Nums.Count; i++)
            {
                if (problem.Operation == '+')
                {
                    result += problem.Nums[i];
                }
                else if (problem.Operation == '*')
                {
                    result *= problem.Nums[i];
                }
            }
            total += result;
        }
        return total.ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }

    public static List<string> GetLines(string input)
    {
        return input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .ToList();
    }

    public class Problem()
    {
        public List<long> Nums = new List<long>();
        public char Operation;
    }
}