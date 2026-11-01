using AdventOfCode.Commons;

namespace AdventOfCode.Usage.WithLocalInput;

/// <summary>
/// Example of how to use the <see cref="Solver{TInput, TResult}"/> for a simple puzzle
///
/// In this example, the input is a succession of integers on different lines
///
/// The first part aims to find the biggest number
///
/// The second part aims to find the sum of all the numbers
/// </summary>
public sealed class Solver()
    : Solver<int[], int>(inputPath: "input.txt")
{
    public override int PartOne(int[] input)
    {
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
        => input.Sum();

    public override int[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(int.Parse)];
}