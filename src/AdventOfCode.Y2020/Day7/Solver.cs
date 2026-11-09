using System.Text.RegularExpressions;

using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day7;

/// <summary>
/// Advent of Code 2020, Day 7: Handy Haversacks.
/// The input is a list of bag rules.
/// Part One asks for the number of bag colors that can eventually contain at least one shiny gold bag.
/// Part Two asks for the total number of bags required inside a single shiny gold bag.
/// </summary>
public sealed class Solver()
    : Solver<string[], int>(inputPath: "input.txt")
{
    public override int PartOne(string[] input)
    {
        var rules = GetBagRules(input);
        return CountBagsThatCanContain("shiny gold", rules);
    }

    public override int PartTwo(string[] input)
    {
        var rules = GetBagRules(input);
        return CountBagsInside("shiny gold", rules);
    }

    public override string[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(line => line)];

    private static Dictionary<string, Dictionary<string, int>> GetBagRules(string[] input)
    {
        var rulePattern = new Regex(
            @"^(?<color>[a-z]+(?: [a-z]+)*) bags contain (?<contents>.+)\.$");

        var bagPattern = new Regex(
            @"^(?<count>[0-9]+) (?<color>[a-z]+(?: [a-z]+)*) bags?$");

        var rules = new Dictionary<string, Dictionary<string, int>>();

        foreach (var line in input)
        {
            var ruleMatch = rulePattern.Match(line);

            if (!ruleMatch.Success)
            {
                throw new FormatException($"Invalid bag rule: {line}");
            }

            var color = ruleMatch.Groups["color"].Value;
            var contents = ruleMatch.Groups["contents"].Value;
            var containedBags = new Dictionary<string, int>();

            if (contents != "no other bags")
            {
                foreach (var entry in contents.Split(", "))
                {
                    var bagMatch = bagPattern.Match(entry);

                    if (!bagMatch.Success)
                    {
                        throw new FormatException($"Invalid bag entry: {entry}");
                    }

                    containedBags.Add(
                        bagMatch.Groups["color"].Value,
                        int.Parse(bagMatch.Groups["count"].Value));
                }
            }

            rules.Add(color, containedBags);
        }

        return rules;
    }

    private static int CountBagsThatCanContain(string targetColor, Dictionary<string, Dictionary<string, int>> rules)
    {
        var containsTarget = new Dictionary<string, bool>();

        foreach (var color in rules.Keys)
        {
            if (containsTarget.ContainsKey(color))
            {
                continue;
            }

            containsTarget[color] = ContainsTarget(color, targetColor, rules, containsTarget);
        }
        return containsTarget.Values.Count(v => v);
    }

    private static bool ContainsTarget(
        string color,
        string targetColor,
        Dictionary<string, Dictionary<string, int>> rules,
        Dictionary<string, bool> containsTarget)
    {
        bool result = false;

        if (containsTarget.ContainsKey(color))
        {
            return containsTarget[color];
        }

        foreach (var containedColor in rules[color].Keys)
        {
            if (containedColor == targetColor || ContainsTarget(containedColor, targetColor, rules, containsTarget))
            {
                result = true;
            }
        }

        containsTarget[color] = result;
        return result;
    }

    private static int CountBagsInside(string color, Dictionary<string, Dictionary<string, int>> rules)
    {
        int count = 0;
        foreach (var kvp in rules[color])
        {
            var containedColor = kvp.Key;
            var containedCount = kvp.Value;
            count += containedCount + containedCount * CountBagsInside(containedColor, rules);
        }
        return count;
    }
}
