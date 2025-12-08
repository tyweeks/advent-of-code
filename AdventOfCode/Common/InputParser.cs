namespace AdventOfCode.Common;

public class InputParser
{
    public static char[,] GetCharArray(string input)
    {
        var lines = input
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

        var rows = lines.Count;
        var columns = lines[0].Length;
        var array = new char[columns, rows];

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                array[x, y] = lines[y][x];
            }
        }

        return array;
    }
}
