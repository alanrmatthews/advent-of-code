using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day10;

/// <summary>
/// Example of how to test the <see cref="Solver{TInput, TResult}"/>
///
/// For each part of the puzzle, we can specify what the example is and what solution it as, along with the
/// expected solution for our puzzle input
/// </summary>
public sealed class LocalInputSolverTest
    : TestEngine<Solver, int[], long>
{
    public override Puzzle PartOne => PuzzleBuilder
        .FromInput(["28",
                    "33",
                    "18",
                    "42",
                    "31",
                    "14",
                    "46",
                    "20",
                    "48",
                    "47",
                    "24",
                    "23",
                    "49",
                    "45",
                    "19",
                    "38",
                    "39",
                    "11",
                    "1",
                    "32",
                    "25",
                    "35",
                    "8",
                    "17",
                    "7",
                    "9",
                    "4",
                    "2",
                    "34",
                    "10",
                    "3"])
        .ParsedAs([28,
                   33,
                   18,
                   42,
                   31,
                   14,
                   46,
                   20,
                   48,
                   47,
                   24,
                   23,
                   49,
                   45,
                   19,
                   38,
                   39,
                   11,
                   1,
                   32,
                   25,
                   35,
                   8,
                   17,
                   7,
                   9,
                   4,
                   2,
                   34,
                   10,
                   3])
        .ExpectsResult(220)
        .WithTheActualSolutionBeing(2170);

    public override Puzzle PartTwo => PuzzleBuilder
        .FromInput(["16",
                    "10",
                    "15",
                    "5",
                    "1",
                    "11",
                    "7",
                    "19",
                    "6",
                    "12",
                    "4"])
        .ParsedAs([16,
                   10,
                   15,
                   5,
                   1,
                   11,
                   7,
                   19,
                   6,
                   12,
                   4])
        .ExpectsResult(8L)
        .WithTheActualSolutionBeing(24803586664192L);
}
