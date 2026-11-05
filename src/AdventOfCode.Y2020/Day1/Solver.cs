using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day1;

/// <summary>
/// Advent of Code 2020, Day 1: Report Repair.
/// The input is an expense report with one integer per line.
/// Part One asks for the product of two entries that sum to 2020.
/// Part Two asks for the product of three entries that sum to 2020.
/// </summary>
public sealed class Solver()
    : Solver<int[], int>(inputPath: "input.txt")
{
    public override int PartOne(int[] input)
    {
        // 2-Sum solution (O(n))
        var parsedInputs = new HashSet<int>();
        foreach (var inputValue in input)
        {
            if (parsedInputs.Contains(2020 - inputValue))
            {
                return inputValue * (2020 - inputValue);
            }

            parsedInputs.Add(inputValue);
        }

        throw new InvalidOperationException("No two numbers sum to 2020.");
    }

    public override int PartTwo(int[] input)
    {
        // 3-Sum solution (O(n²))
        Array.Sort(input);
        for (var i = 0; i < input.Length - 2; i++)
        {
            var j = i + 1;
            var k = input.Length - 1;
            while (j < k)
            {
                var sum = input[i] + input[j] + input[k];
                if (sum == 2020)
                {
                    return input[i] * input[j] * input[k];
                }

                if (sum < 2020)
                {
                    j++;
                }
                else
                {
                    k--;
                }
            }
        }

        throw new InvalidOperationException("No three numbers sum to 2020.");
    }

    public override int[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(int.Parse)];
}
