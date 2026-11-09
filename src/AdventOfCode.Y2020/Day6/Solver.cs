using System.Text.RegularExpressions;

using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day6;

/// <summary>
/// Advent of Code 2020, Day 6: Custom Customs.
/// The input is a list of groups' answers to customs questions.
/// Part One asks for the sum of counts of questions answered "yes" by anyone in each group.
/// Part Two asks for the sum of counts of questions answered "yes" by everyone in each group.
/// </summary>
public sealed class Solver()
    : Solver<string[], int>(inputPath: "input.txt")
{
    public override int PartOne(string[] input)
        => input.Sum(GetGroupYesCount);

    public override int PartTwo(string[] input)
        => input.Sum(GetGroupAllYesCount);

    public override string[] ParseInput(IEnumerable<string> input)
    {
        var groups = new List<string>();
        var currentGroup = new List<string>();
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                groups.Add(string.Join(",", currentGroup));
                currentGroup.Clear();
            }
            else
            {
                currentGroup.Add(line);
            }
        }
        if (currentGroup.Count > 0)
            groups.Add(string.Join(",", currentGroup));

        return groups.ToArray();
    }

    private static int GetGroupYesCount(string input)
        => input.Replace(",", "").Distinct().Count();

    private static int GetGroupAllYesCount(string input)
    {
        var people = input.Split(',');
        var commonAnswers = people[0].ToHashSet();
        foreach (var person in people.Skip(1))
        {
            commonAnswers.IntersectWith(person);
        }
        return commonAnswers.Count();
    }

}
