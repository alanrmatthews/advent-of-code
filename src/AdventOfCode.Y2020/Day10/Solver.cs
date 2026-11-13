using System.IO.Pipes;
using System.Text.RegularExpressions;

using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day10;

/// <summary>
/// Advent of Code 2020, Day 10: Adapter Array.
/// The input is a list of adapter joltage ratings.
/// Part One asks for the product of the number of 1-jolt and 3-jolt differences.
/// Part Two asks for the number of distinct valid adapter arrangements.
/// </summary>
public sealed class Solver()
    : Solver<int[], long>(inputPath: "input.txt")
{
    public override long PartOne(int[] input)
        => GetJoltDifferences(GetJoltageArray(input));

    public override long PartTwo(int[] input)
        => GetJoltageArrangements(GetJoltageArray(input), 0, []);

    public override int[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(int.Parse)];

    private static int[] GetJoltageArray(int[] input)
    {
        Array.Sort(input);
        var Joltages = new int[input.Length + 2];
        Array.Copy(input, 0, Joltages, 1, input.Length);
        Joltages[0] = 0;
        Joltages[^1] = Joltages[^2] + 3;

        return Joltages;
    }

    private static int GetJoltDifferences(int[] input)
    {
        var OneJoltDifferences = 0;
        var ThreeJoltDifferences = 0;

        for (var i = 1; i < input.Length; i++)
        {
            var difference = input[i] - input[i-1];
            if (difference == 1)
            {
                OneJoltDifferences++;
            }
            else if (difference == 3)
            {
                ThreeJoltDifferences++;
            }
        }

        return OneJoltDifferences * ThreeJoltDifferences;
    }

    private static long GetJoltageArrangements(int[] input, int index, Dictionary<int, long> knownArrangements)
    {
        if (knownArrangements.TryGetValue(index, out var cachedArrangements))
        {
            return cachedArrangements;
        }

        if (index == input.Length - 1)
        {
            return knownArrangements[index] = 1;
        }

        long arrangements = 0;
        for (var i = index + 1; i < input.Length && input[i] - input[index] <= 3; i++)
        {
            arrangements += GetJoltageArrangements(input, i, knownArrangements);
        }

        return knownArrangements[index] = arrangements;
    }
}
