using System.Text.RegularExpressions;

using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day2;

/// <summary>
/// Advent of Code 2020, Day 2: Password Philosophy.
/// The input is a list of password entries, one per line.
/// Part One asks for the number of valid passwords according to the old policy.
/// Part Two asks for the number of valid passwords according to the new policy.
/// </summary>
public sealed class Solver()
    : Solver<PasswordEntry[], int>(inputPath: "input.txt")
{
    public override int PartOne(PasswordEntry[] input)
        => input.Count(entry => entry.IsValidPart1());

    public override int PartTwo(PasswordEntry[] input)
        => input.Count(entry => entry.IsValidPart2());

    private static readonly Regex PasswordPattern = new(
        @"\A(?<lowestCount>[0-9]+)-(?<highestCount>[0-9]+) (?<character>[a-z]): (?<password>[a-z]+)\z");

    public override PasswordEntry[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(line =>
    {
        var match = PasswordPattern.Match(line);

        if (!match.Success)
        {
            throw new FormatException($"Invalid password entry: '{line}'.");
        }

        return new PasswordEntry(
            int.Parse(match.Groups["lowestCount"].Value),
            int.Parse(match.Groups["highestCount"].Value),
            match.Groups["character"].Value[0],
            match.Groups["password"].Value);
    })];
}

public sealed record PasswordEntry(
    int FirstPosition,
    int SecondPosition,
    char Character,
    string Password)
{
    public bool IsValidPart1()
    {
        var count = Password.Count(c => c == Character);
        return count >= FirstPosition && count <= SecondPosition;
    }

    public bool IsValidPart2()
    {
        var firstMatch = Password[FirstPosition - 1] == Character;
        var secondMatch = Password[SecondPosition - 1] == Character;
        return firstMatch ^ secondMatch;
    }
}