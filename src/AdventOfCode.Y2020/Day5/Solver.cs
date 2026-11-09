using System.Text.RegularExpressions;

using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day5;

/// <summary>
/// Advent of Code 2020, Day 5: Binary Boarding.
/// The input is a list of boarding passes, each specifying a seat on the plane.
/// Part One asks for the highest seat ID on a boarding pass.
/// Part Two asks for the missing seat ID in the list.
/// </summary>
public sealed class Solver()
    : Solver<string[], int>(inputPath: "input.txt")
{
    public override int PartOne(string[] input)
        => input.Max(GetSeatId);

    public override int PartTwo(string[] input)
    {
        var seatIds = input.Select(GetSeatId).OrderBy(id => id).ToArray();
        for (int i = 1; i < seatIds.Length; i++)
        {
            if (seatIds[i] != seatIds[i - 1] + 1)
                return seatIds[i - 1] + 1;
        }
        return -1;
    }

    public override string[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(line => line)];

    private static int GetSeatId(string input)
    {
        int minRow = 0;
        int maxRow = 127;
        int minSeat = 0;
        int maxSeat = 7;

        foreach (char c in input)
        {
            if (c == 'F')
                maxRow = (minRow + maxRow) / 2;
            else if (c == 'B')
                minRow = (minRow + maxRow + 1) / 2;
            else if (c == 'L')
                maxSeat = (minSeat + maxSeat) / 2;
            else if (c == 'R')
                minSeat = (minSeat + maxSeat + 1) / 2;
        }
        return minRow * 8 + minSeat;
    }

}
