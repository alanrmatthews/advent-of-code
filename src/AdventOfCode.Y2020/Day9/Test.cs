using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day9;

/// <summary>
/// Example of how to test the <see cref="Solver{TInput, TResult}"/>
///
/// For each part of the puzzle, we can specify what the example is and what solution it as, along with the
/// expected solution for our puzzle input
/// </summary>
public sealed class LocalInputSolverTest
    : TestEngine<Solver, long[], long>
{
    public override Puzzle PartOne => PuzzleBuilder
        .FromInput(["35",
                    "20",
                    "15",
                    "25",
                    "47",
                    "40",
                    "62",
                    "55",
                    "65",
                    "95",
                    "102",
                    "117",
                    "150",
                    "182",
                    "127",
                    "219",
                    "299",
                    "277",
                    "309",
                    "576"])
        .ParsedAs([35L,
                   20L,
                   15L,
                   25L,
                   47L,
                   40L,
                   62L,
                   55L,
                   65L,
                   95L,
                   102L,
                   117L,
                   150L,
                   182L,
                   127L,
                   219L,
                   299L,
                   277L,
                   309L,
                   576L])
        .ExpectsResult(127L)
        .WithTheActualSolutionBeing(22477624L);

    public override Puzzle PartTwo => PuzzleBuilder
        .FromInput(["35",
                    "20",
                    "15",
                    "25",
                    "47",
                    "40",
                    "62",
                    "55",
                    "65",
                    "95",
                    "102",
                    "117",
                    "150",
                    "182",
                    "127",
                    "219",
                    "299",
                    "277",
                    "309",
                    "576"])
        .ParsedAs([35L,
                   20L,
                   15L,
                   25L,
                   47L,
                   40L,
                   62L,
                   55L,
                   65L,
                   95L,
                   102L,
                   117L,
                   150L,
                   182L,
                   127L,
                   219L,
                   299L,
                   277L,
                   309L,
                   576L])
        .ExpectsResult(62L)
        .WithTheActualSolutionBeing(2980044L);
}
