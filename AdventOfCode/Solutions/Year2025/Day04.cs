using AdventOfCode.Common;

namespace AdventOfCode.Solutions.Year2025;

public class Day04 : ISolution
{
    public string SolvePart1(string input)
    {
        var map = ParseInput(input);
        var accessMap = GetAccessMap(map);
        var count = 0;

        for (int y = 0; y < accessMap.GetLength(1); y++)
        {
            for (int x = 0; x < accessMap.GetLength(0); x++)
            {
                if (accessMap[x, y] == 'x')
                    count++;
            }
        }

        return count.ToString();
    }

    public string SolvePart2(string input)
    {
        var count = 0;
        var map = ParseInput(input);
        var accessMap = GetAccessMap(map);
        bool removingRolls = true;

        while (removingRolls)
        {
            removingRolls = false;
            for (int y = 0; y < accessMap.GetLength(1); y++)
            {
                for (int x = 0; x < accessMap.GetLength(0); x++)
                {
                    if (accessMap[x, y] == 'x')
                    {
                        count++;
                        removingRolls = true;
                    }
                }
            }

            var removedRollsMap = RemoveRolls(accessMap);
            accessMap = GetAccessMap(removedRollsMap);
        }

        return count.ToString();
    }

    public static char[,] GetAccessMap(char[,] map)
    {
        var accessMap = new char[map.GetLength(0), map.GetLength(1)];

        PrintMap(map);

        for (int y = 0; y < map.GetLength(1); y++)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                if (map[x, y] == '@')
                {
                    int adjacentRolls = 0;

                    if (x > 0 && map[x - 1, y] == '@')
                        adjacentRolls++;

                    if (x > 0 && y > 0 && map[x - 1, y - 1] == '@')
                        adjacentRolls++;

                    if (y > 0 && map[x, y - 1] == '@')
                        adjacentRolls++;

                    if (x < map.GetLength(0) - 1 && y > 0 && map[x + 1, y - 1] == '@')
                        adjacentRolls++;

                    if (x < map.GetLength(0) - 1 && map[x + 1, y] == '@')
                        adjacentRolls++;

                    if (x < map.GetLength(0) - 1 && y < map.GetLength(1) - 1 && map[x + 1, y + 1] == '@')
                        adjacentRolls++;

                    if (y < map.GetLength(1) - 1 && map[x, y + 1] == '@')
                        adjacentRolls++;

                    if (x > 0 && y < map.GetLength(1) - 1 && map[x - 1, y + 1] == '@')
                        adjacentRolls++;


                    if (adjacentRolls < 4)
                        accessMap[x, y] = 'x';
                    else
                        accessMap[x, y] = '@';
                }
                else
                {
                    accessMap[x, y] = map[x, y];
                }
            }
        }

        PrintMap(accessMap);

        return accessMap;
    }

    public static char[,] RemoveRolls(char[,] map)
    {
        var removedMap = new char[map.GetLength(0), map.GetLength(1)];

        for (int y = 0; y < map.GetLength(1); y++)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                if (map[x, y] != 'x')
                    removedMap[x, y] = map[x, y];
                else
                    removedMap[x, y] = '.';
            }
        }

        return removedMap; 
    }

    private static void PrintMap(char[,] map)
    {
        Console.WriteLine("Printing map...");
        for (int y = 0; y < map.GetLength(1); y++)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                Console.Write(map[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private static char[,] ParseInput(string input)
    {
        var lines = input
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim())
                .ToList();

        var rows = lines.Count;
        var columns = lines[0].Length;
        var map = new char[columns, rows];

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                map[x, y] = lines[y][x];
            }
        }

        return map;
    }
}