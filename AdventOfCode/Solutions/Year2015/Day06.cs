using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2015;

public class Day06 : ISolution
{
    public string SolvePart1(string input)
    {
        bool[,] grid = new bool[1000, 1000];
        var instructions = ParseInput(input);

        foreach (var instructionString in instructions )
        {
            var instruction = new Instruction(instructionString);
            
            for (int y = instruction.StartY; y <= instruction.EndY; y++)
            {
                for (int x = instruction.StartX; x <= instruction.EndX; x++)
                {
                    if (instruction.Action == "on")
                    {
                        grid[x,y] = true;
                    }
                    if (instruction.Action == "off")
                    {
                        grid[x, y] = false;
                    }
                    if (instruction.Action == "toggle")
                    {
                        grid[x, y] = !grid[x,y];
                    }
                }
            }
        }

        var lightsOn = 0;
        for (int y = 0; y < 1000; y++)
        {
            for (int x = 0; x < 1000; x++)
            {
                lightsOn += grid[x, y] ? 1 : 0;
            }
        }

        return lightsOn.ToString();
    }

    public string SolvePart2(string input)
    {
        int[,] grid = new int[1000, 1000];
        var instructions = ParseInput(input);

        foreach (var instructionString in instructions)
        {
            var instruction = new Instruction(instructionString);

            for (int y = instruction.StartY; y <= instruction.EndY; y++)
            {
                for (int x = instruction.StartX; x <= instruction.EndX; x++)
                {
                    if (instruction.Action == "on")
                    {
                        grid[x, y] += 1;
                    }
                    if (instruction.Action == "off")
                    {
                        grid[x, y] -= 1;
                        grid[x, y] = Math.Max(grid[x, y], 0);
                    }
                    if (instruction.Action == "toggle")
                    {
                        grid[x, y] += 2;
                    }
                }
            }
        }

        var totalBrighgness = 0;
        for (int y = 0; y < 1000; y++)
        {
            for (int x = 0; x < 1000; x++)
            {
                totalBrighgness += grid[x, y];
            }
        }

        return totalBrighgness.ToString();
    }

    private static List<string> ParseInput(string input)
    {
        return input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .ToList();
    }

    private class Instruction
    {
        public string Action;
        public int StartX;
        public int StartY;
        public int EndX;
        public int EndY;

        public Instruction(string instructionString)
        {
            var parts = instructionString.Split(' ');
            if (parts.Length == 4)
            {
                Action = parts[0];
                StartX = int.Parse(parts[1].Split(',')[0]);
                StartY = int.Parse(parts[1].Split(',')[1]);
                EndX = int.Parse(parts[3].Split(',')[0]);
                EndY = int.Parse(parts[3].Split(',')[1]);
            }
            else
            {
                Action = parts[1];
                StartX = int.Parse(parts[2].Split(',')[0]);
                StartY = int.Parse(parts[2].Split(',')[1]);
                EndX = int.Parse(parts[4].Split(',')[0]);
                EndY = int.Parse(parts[4].Split(',')[1]);
            }
        }
    }
}
