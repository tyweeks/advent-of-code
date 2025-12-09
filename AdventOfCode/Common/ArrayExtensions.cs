namespace AdventOfCode.Common;

public static class ArrayExtensions
{
    public static char[,] DeepCopy(this char[,] source)
    {
        int rows = source.GetLength(0);
        int cols = source.GetLength(1);

        var result = new char[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = source[i, j];

        return result;
    }
}