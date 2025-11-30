using AdventOfCode2025.Common;

int dayNumber = 0;

var problem = ProblemFactory.Get(dayNumber);
var input = ProblemFactory.GetInput(dayNumber);

Console.WriteLine($"Day {dayNumber:D2} Solutions:");
Console.WriteLine($"Part 1: {problem.SolvePart1(input)}");
Console.WriteLine($"Part 2: {problem.SolvePart2(input)}");