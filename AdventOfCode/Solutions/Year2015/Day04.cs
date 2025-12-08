using AdventOfCode.Common;
using System.Threading.Tasks.Dataflow;

namespace AdventOfCode.Solutions.Year2015;

public class Day04 : ISolution
{
    public string SolvePart1(string input)
    {
        for (int i = 0; ; i++)
        {
            var testString = input + i;
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(testString);
            var hashBytes = md5.ComputeHash(inputBytes);
            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            if (hashString.StartsWith("00000"))
            {
                return i.ToString();
            }
        }
    }

    public string SolvePart2(string input)
    {
        for (int i = 0; ; i++)
        {
            var testString = input + i;
            using var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(testString);
            var hashBytes = md5.ComputeHash(inputBytes);
            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            if (hashString.StartsWith("000000"))
            {
                return i.ToString();
            }
        }
    }
}
