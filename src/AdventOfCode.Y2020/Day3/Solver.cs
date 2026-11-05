using System.Text.RegularExpressions;

using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day3;

/// <summary>
/// Advent of Code 2020, Day 3: Toboggan Trajectory.
/// The input is a map of the slope, with each line representing a row and each character representing an open square (.) or a tree (#).
/// Part One asks for the number of trees encountered when following a slope of right 3, down 1.
/// Part Two asks for the product of the number of trees encountered for multiple slopes.
/// </summary>
public sealed class Solver()
    : Solver<string[], uint>(inputPath: "input.txt")
{
    public override uint PartOne(string[] input)
        => CountTrees(input, right: 3, down: 1);

    public override uint PartTwo(string[] input)
        => CountTrees(input, right: 1, down: 1)
            * CountTrees(input, right: 3, down: 1)
            * CountTrees(input, right: 5, down: 1)
            * CountTrees(input, right: 7, down: 1)
            * CountTrees(input, right: 1, down: 2);

    public override string[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(line => line)];

    private static uint CountTrees(string[] map, int right, int down)
    {
        int width = map[0].Length;
        int height = map.Length;
        uint trees = 0;
        int x = 0;
        for (int y = 0; y < height; y += down)
        {
            if (map[y][x % width] == '#')
            {
                trees++;
            }
            x += right;
        }
        return trees;
    }
}
