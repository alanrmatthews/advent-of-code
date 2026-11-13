using System.IO.Pipes;
using System.Text.RegularExpressions;

using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day9;

/// <summary>
/// Advent of Code 2020, Day 9: Encoding Error.
/// The input is a list of numbers.
/// Part One asks for the first number that is not the sum of two of the previous 25 numbers.
/// Part Two asks for the encryption weakness: the sum of the smallest and largest numbers in a contiguous range summing to the invalid number.
/// </summary>
public sealed class Solver()
    : Solver<long[], long>(inputPath: "input.txt")
{
    public override long PartOne(long[] input)
        => FindInvalidNumber(input, input.Length < 25? 5 : 25);

    public override long PartTwo(long[] input)
        => FindEncryptionWeakness(input, FindInvalidNumber(input, input.Length < 25? 5 : 25));

    public override long[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(long.Parse)];

    private static long FindInvalidNumber(long[] input, int preambleLength)
    {
        var previousNumbers = new HashSet<long>(input.Take(preambleLength));
        for (var i = preambleLength; i < input.Length; i++)
        {
            if (!previousNumbers.Any(number => previousNumbers.Contains(input[i] - number) && input[i] - number != number))
            {
                return input[i];
            }

            previousNumbers.Remove(input[i - preambleLength]);
            previousNumbers.Add(input[i]);
        }

        return -1;
    }

    private static long FindEncryptionWeakness(long[] input, long invalidNumber)
    {
        // Brute force for now.  We could probably cache some sums (sum of 2 elements, then 3, then 4, etc...)
        for (var start = 0; start < input.Length; start++)
        {
            var sum = 0L;
            var min = long.MaxValue;
            var max = long.MinValue;
            for (var end = start; end < input.Length; end++)
            {
                var number = input[end];
                sum += number;
                min = Math.Min(min, number);
                max = Math.Max(max, number);

                if (sum == invalidNumber)
                {
                    return min + max;
                }

                if (sum > invalidNumber)
                {
                    break;
                }
            }
        }

        return -1;
    }
}
