using AdventOfCode.Common;
using System.Numerics;

namespace AdventOfCode.Solutions.Year2025;

public class Day09 : ISolution
{
    public string SolvePart1(string input)
    {
        var vectors = GetVectors(input);
        double maxArea = 0;

        for (int i = 0; i < vectors.Count - 1; i++)
        {
            for (int j = i + 1; j < vectors.Count; j++)
            {
                var v1 = vectors[i];
                var v2 = vectors[j];

                double x = Math.Abs(v1.X - v2.X)+1;
                double y = Math.Abs(v1.Y - v2.Y)+1;
                double area = x * y;

                maxArea = Math.Max(maxArea, area);
            }
        }

        return maxArea.ToString("F0");
    }

    public string SolvePart2(string input)
    {
        var vectors = GetVectors(input);
        var map = GetBorderMap(vectors);

        Console.WriteLine("Border Map");
        //PrintMap(map);

        //Console.WriteLine("\nFilled Map");
        //var filledMap = FillMap(map);

        //PrintMap(filledMap);

        List<VectorPair> pairs = new List<VectorPair>();

        for (int i = 0; i < vectors.Count - 1; i++)
        {
            for (int j = i + 1; j < vectors.Count; j++)
            {
                var v1 = vectors[i];
                var v2 = vectors[j];

                double x = Math.Abs(v1.X - v2.X) + 1;
                double y = Math.Abs(v1.Y - v2.Y) + 1;
                double area = x * y;

                var pair = new VectorPair();
                pair.v1 = v1;
                pair.v2 = v2;
                pair.area = area;

                pairs.Add(pair);
            }
        }

        var orderedPairs = pairs.OrderByDescending(x => x.area).ToList();

        foreach(VectorPair pair in orderedPairs) 
        {
            Console.WriteLine($"{pair.area}: {pair.v1.ToString()} - {pair.v2.ToString()}");
            var v1 = pair.v1;
            var v2 = pair.v2;    

            if (IsAreaFilled(v1, v2, map))
                return pair.area.ToString("F0");
        }

        return "";
    }

    public class VectorPair
    {
        public Vector2 v1;
        public Vector2 v2;
        public double area;
    }

    private static bool IsAreaFilled(Vector2 v1, Vector2 v2, char[][] map)
    { 
        int startY = (int)Math.Min(v1.Y, v2.Y) - 1;
        int endY = (int)Math.Max(v1.Y, v2.Y) - 1;

        int startX = (int)Math.Min(v1.X, v2.X) - 1;
        int endX = (int)Math.Max(v1.X, v2.X) - 1;

        // check top border
        for (int x = startX; x < endX; x++)
        {
            if (map[x][startY] == '.')
            {
                Console.WriteLine($"Checking [{x},{startY}]");
                // check left
                int tempY = startY;
                bool inWall = false;
                int bordersCrossed = 0;

                while (tempY > 0)
                {
                    tempY--;

                    if (map[x][tempY] == '#')
                    {
                        inWall = !inWall;
                        if (!inWall)
                            bordersCrossed++;
                    }
                    else if (map[x][tempY] == 'X' && !inWall)
                    {
                        bordersCrossed++;
                    }
                }

                if (bordersCrossed % 2 == 0)
                {
                    return false;
                }

                while (map[x][startY] == '.')
                    { x++; }
            }
        }

        // check bottom border
        for (int x = startX; x < endX; x++)
        {
            if (map[x][endY] == '.')
            {
                Console.WriteLine($"Checking [{x},{endY}]");
                // check left
                int tempY = endY;
                bool inWall = false;
                int bordersCrossed = 0;

                while (tempY > 0)
                {
                    tempY--;

                    if (map[x][tempY] == '#')
                    {
                        inWall = !inWall;
                        if (!inWall)
                            bordersCrossed++;
                    }
                    else if (map[x][tempY] == 'X' && !inWall)
                    {
                        bordersCrossed++;
                    }
                }

                if (bordersCrossed % 2 == 0)
                {
                    return false;
                }

                while (map[x][endY] == '.')
                { x++; }
            }
        }

        // check left border
        for (int y = startY; y < endY; y++)
        {
            if (map[startX][y] == '.')
            {
                Console.WriteLine($"Checking [{startX},{y}]");
                // check left
                int tempX = startX;
                bool inWall = false; // maybe set differently
                int bordersCrossed = 0;

                while (tempX > 0)
                {
                    tempX--;

                    if (map[tempX][y] == '#')
                    {
                        inWall = !inWall;
                        if (!inWall)
                            bordersCrossed++;
                    }
                    else if (map[tempX][y] == 'X' && !inWall)
                    {
                        bordersCrossed++;
                    }
                }

                if (bordersCrossed % 2 == 0)
                {
                    return false;
                }

                while (map[startX][y] == '.')
                { y++; }
            }
        }

        // check right border
        for (int y = startY; y < endY; y++)
        {
            if (map[endX][y] == '.')
            {
                Console.WriteLine($"Checking [{endX},{y}]");
                // check left
                int tempX = endX;
                bool inWall = false;
                int bordersCrossed = 0;

                while (tempX > 0)
                {
                    tempX--;

                    if (map[tempX][y] == '#')
                    {
                        inWall = !inWall;
                        if (!inWall)
                            bordersCrossed++;
                    }
                    else if (map[tempX][y] == 'X' && !inWall)
                    {
                        bordersCrossed++;
                    }
                }

                if (bordersCrossed % 2 == 0)
                {
                    return false;
                }

                while (map[endX][y] == '.')
                { y++; }
            }
        }

        return true;
    }


    private static char[][] FillMap(char[][] map)
    {
        int width = map.Length;
        int height = map[0].Length;

        // Deep copy
        char[][] newMap = new char[width][];
        for (int x = 0; x < width; x++)
        {
            newMap[x] = new char[height];
            Array.Copy(map[x], newMap[x], height);
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (map[x][y] == '.')
                {
                    // check left
                    int tempX = x;
                    bool inWall = false;
                    int bordersCrossed = 0;

                    while (tempX > 0)
                    {
                        tempX--;

                        if (map[tempX][y] == '#')
                        {
                            inWall = !inWall;
                            if (!inWall)
                                bordersCrossed++;
                        }
                        else if (map[tempX][y] == 'X' && !inWall)
                        {
                            bordersCrossed++;
                        }
                    }

                    if (bordersCrossed % 2 == 1)
                    {
                        newMap[x][y] = 'X';
                    }
                }
            }
        }

        return newMap;
    }


    private static void PrintMap(char[][] map)
    {
        int width = map.Length;
        int height = map[0].Length;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(map[x][y]);
            }
            Console.WriteLine();
        }
    }

    private static char[][] GetBorderMap(List<Vector2> redVectors)
    {
        int maxX = 0;
        int maxY = 0;

        foreach (var vector in redVectors)
        {
            maxX = Math.Max(maxX, (int)vector.X);
            maxY = Math.Max(maxY, (int)vector.Y);
        }

        char[][] map = new char[maxX][];
        for (int x = 0; x < maxX; x++)
        {
            map[x] = new char[maxY];

            for (int y = 0; y < maxY; y++)
                map[x][y] = '.';
        }

        for (int i = 0; i < redVectors.Count; i++)
        {
            var vector = redVectors[i];
            map[(int)vector.X - 1][(int)vector.Y - 1] = '#';

            Vector2 nextVector = new();
            if (i < redVectors.Count - 1)
            {
                nextVector = redVectors[i + 1];
            }
            else
            {
                nextVector = redVectors[0];
            }

            if (vector.X == nextVector.X)
            {
                for (float y = Math.Min(vector.Y, nextVector.Y)+1; y < Math.Max(vector.Y, nextVector.Y); y++)
                {
                    map[(int)vector.X - 1][(int)y-1] = 'X';
                }
            }
            else if (vector.Y == nextVector.Y)
            {
                for (float x = Math.Min(vector.X, nextVector.X)+1; x < Math.Max(vector.X, nextVector.X); x++)
                {
                    map[(int)x-1][(int)vector.Y - 1] = 'X';
                }
            }

        }

        return map;
    }

    private static List<Vector2> GetVectors(string input)
    {
        var lines = InputParser.ToStringArray(input);
        var result = new List<Vector2>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            var vector = new Vector2(int.Parse(parts[0]), int.Parse(parts[1]));
            result.Add(vector);
        }

        return result;
    }
}