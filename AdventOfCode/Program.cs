using AdventOfCode.Common;

int yearNumber = 2025;
int dayNumber = 9;

var problem = SolutionFactory.GetSolution(yearNumber, dayNumber);
var input = SolutionFactory.GetInput(yearNumber, dayNumber);

Console.WriteLine($"Day {dayNumber:D2} Solutions:");
Console.WriteLine($"Part 1: {problem.SolvePart1(input)}");
Console.WriteLine($"Part 2: {problem.SolvePart2(input)}");