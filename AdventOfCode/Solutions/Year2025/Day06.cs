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
        var charArray = InputParser.ToCharGrid(input);
        var problems = new List<Problem>();
        Problem currentProblem = new();

        for (int x = charArray.GetLength(0)-1; x >= 0; x--)
        {
            string numString = "";
            bool onCurrentProblem = false;
            for (int y = 0; y < charArray.GetLength(1); y++)
            {
                if (int.TryParse(charArray[x,y].ToString(), out int val))
                {
                    numString += charArray[x, y];
                    onCurrentProblem = true;
                }
                else if (charArray[x, y] != ' ')
                {
                    currentProblem.Operation = charArray[x, y];
                    onCurrentProblem = true;
                }
            }
            if (numString != "")
            {
                int num = int.Parse(numString);
                currentProblem.Nums.Add(num);
            }

            if (!onCurrentProblem)
            {
                problems.Add(currentProblem);
                currentProblem = new Problem();
            }
        }
        problems.Add(currentProblem);

        long total = 0;
        foreach (var problem in problems)
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