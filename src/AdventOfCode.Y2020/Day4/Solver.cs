using System.Text.RegularExpressions;

using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day4;

/// <summary>
/// Advent of Code 2020, Day 4: Passport Processing.
/// The input is a list of passport entries, with each passport separated by a blank line.
/// Part One asks for the number of valid passports based on the presence of required fields.
/// Part Two asks for the number of valid passports based on stricter field validation rules.
/// </summary>
public sealed class Solver()
    : Solver<string[], int>(inputPath: "input.txt")
{
    public override int PartOne(string[] input)
        => GetValidPassports(input, strict: false);

    public override int PartTwo(string[] input)
        => GetValidPassports(input, strict: true);

    public override string[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(line => line)];

    private int GetValidPassports(string[] lines, bool strict)
    {
        int validPassports = 0;
        var currentPassport = new Passport();

        foreach (var line in lines)
        {
            foreach (Match match in Regex.Matches(line, @"(?<key>[a-z]{3}):(?<value>\S+)"))
            {
                var value = match.Groups["value"].Value;


                currentPassport = match.Groups["key"].Value switch
                {
                    "ecl" => currentPassport with { Ecl = value },
                    "pid" => currentPassport with { Pid = value },
                    "eyr" => currentPassport with { Eyr = int.Parse(value) },
                    "hcl" => currentPassport with { Hcl = value },
                    "byr" => currentPassport with { Byr = int.Parse(value) },
                    "iyr" => currentPassport with { Iyr = int.Parse(value) },
                    "cid" => currentPassport with { Cid = value },
                    "hgt" => currentPassport with { Hgt = value },
                    var key => throw new FormatException($"Unknown field: {key}")
                };
            }
            if (string.IsNullOrWhiteSpace(line))
            {
                if (currentPassport.IsValid(strict))
                    validPassports++;
                currentPassport = new Passport();
            }
        }

        if (currentPassport.IsValid(strict))
            validPassports++;

        return validPassports;
    }
}

public sealed record Passport(
    string Ecl = "",
    string Pid = "",
    int Eyr = -1,
    string Hcl = "",
    int Byr = -1,
    int Iyr = -1,
    string Cid = "",
    string Hgt = "")
{
    public bool IsValid(bool strict)
    {
        if (!strict)
        {
            return Byr != -1 &&
                   Iyr != -1 &&
                   !string.IsNullOrEmpty(Ecl) &&
                   !string.IsNullOrEmpty(Pid) &&
                   Eyr != -1 &&
                   !string.IsNullOrEmpty(Hcl) &&
                   !string.IsNullOrEmpty(Hgt);
        }

        if (Byr < 1920 || Byr > 2002)
            return false;

        if (Iyr < 2010 || Iyr > 2020)
            return false;

        if (Eyr < 2020 || Eyr > 2030)
            return false;

        if (Hgt.EndsWith("cm"))
        {
            if (!int.TryParse(Hgt[..^2], out var hgtCm) || hgtCm < 150 || hgtCm > 193)
                return false;
        }
        else if (Hgt.EndsWith("in"))
        {
            if (!int.TryParse(Hgt[..^2], out var hgtIn) || hgtIn < 59 || hgtIn > 76)
                return false;
        }
        else
        {
            return false;
        }

        if (!Regex.IsMatch(Hcl, @"^#[0-9a-f]{6}$"))
            return false;

        if (!Regex.IsMatch(Ecl, @"^(amb|blu|brn|gry|grn|hzl|oth)$"))
            return false;

        if (!Regex.IsMatch(Pid, @"^\d{9}$"))
            return false;

        return true;
    }
};
