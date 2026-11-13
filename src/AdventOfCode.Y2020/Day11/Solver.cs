using System.IO.Pipes;
using System.Text.RegularExpressions;

using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day11;

/// <summary>
/// Advent of Code 2020, Day 11: Seating System.
/// The input is a seating area with floor, empty seats, and occupied seats.
/// Part One asks for the number of occupied seats after adjacent-seat rules stabilize.
/// Part Two asks for the number of occupied seats after visible-seat rules stabilize.
/// </summary>
public sealed class Solver()
    : Solver<string[], int>(inputPath: "input.txt")
{
    public override int PartOne(string[] input)
        => CountOccupiedSeats(ModelSeating(input));

    public override int PartTwo(string[] input)
        => CountOccupiedSeats(ModelSeating(input, visibleSeats: true, tolerance: 5));

    public override string[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(line => line)];

    private static int CountOccupiedSeats(string[] seats)
        => seats.Sum(row => row.Count(seat => seat == '#'));

    private static string[] ModelSeating(string[] seats, bool visibleSeats = false, int tolerance = 4)
    {
        string[] newSeats = ApplySeatingRules(seats, visibleSeats, tolerance);
        while (!newSeats.SequenceEqual(seats))
        {
            seats = newSeats;
            newSeats = ApplySeatingRules(seats, visibleSeats, tolerance);
        }

        return seats;
    }

    private static string[] ApplySeatingRules(string[] seats, bool visibleSeats, int tolerance)
    {
        string[] newSeats = new string[seats.Length];
        for (int row = 0; row < seats.Length; row++)
        {
            char[] newRow = seats[row].ToCharArray();
            for (int column = 0; column < seats[row].Length; column++)
            {
                char seat = seats[row][column];
                if (seat == '.')
                    continue;

                int occupiedNeighbors = visibleSeats
                    ? OccupiedVisibleNeighbors(seats, row, column)
                    : OccupiedNeighbors(seats, row, column);

                if (seat == 'L' && occupiedNeighbors == 0)
                    newRow[column] = '#';
                else if (seat == '#' && occupiedNeighbors >= tolerance)
                    newRow[column] = 'L';
            }

            newSeats[row] = new string(newRow);
        }

        return newSeats;
    }

    private static int OccupiedNeighbors(string[] seats, int row, int column)
    {
        int occupiedNeighbors = 0;
        for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
        {
            for (int columnOffset = -1; columnOffset <= 1; columnOffset++)
            {
                if (rowOffset == 0 && columnOffset == 0)
                {
                    continue;
                }

                int neighborRow = row + rowOffset;
                int neighborColumn = column + columnOffset;
                if (neighborRow >= 0 && neighborRow < seats.Length
                    && neighborColumn >= 0 && neighborColumn < seats[neighborRow].Length
                    && seats[neighborRow][neighborColumn] == '#')
                {
                    occupiedNeighbors++;
                }
            }
        }

        return occupiedNeighbors;
    }

    private static int OccupiedVisibleNeighbors(string[] seats, int row, int column)
    {
        int occupiedNeighbors = 0;
        for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
        {
            for (int columnOffset = -1; columnOffset <= 1; columnOffset++)
            {
                if (rowOffset == 0 && columnOffset == 0)
                    continue;

                int neighborRow = row + rowOffset;
                int neighborColumn = column + columnOffset;
                while (neighborRow >= 0 && neighborRow < seats.Length
                    && neighborColumn >= 0 && neighborColumn < seats[neighborRow].Length)
                {
                    char seat = seats[neighborRow][neighborColumn];
                    if (seat != '.')
                    {
                        if (seat == '#')
                            occupiedNeighbors++;
                        break;
                    }

                    neighborRow += rowOffset;
                    neighborColumn += columnOffset;
                }
            }
        }

        return occupiedNeighbors;
    }
}
