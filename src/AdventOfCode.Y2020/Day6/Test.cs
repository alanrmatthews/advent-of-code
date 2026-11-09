using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day6;

/// <summary>
/// Example of how to test the <see cref="Solver{TInput, TResult}"/>
///
/// For each part of the puzzle, we can specify what the example is and what solution it as, along with the
/// expected solution for our puzzle input
/// </summary>
public sealed class LocalInputSolverTest
    : TestEngine<Solver, string[], int>
{
    public override Puzzle PartOne => PuzzleBuilder
        .FromInput(["abc",
                    "",
                    "a",
                    "b",
                    "c",
                    "",
                    "ab",
                    "ac",
                    "",
                    "a",
                    "a",
                    "a",
                    "a",
                    "",
                    "b"])
        .ParsedAs(["abc",
                   "a,b,c",
                   "ab,ac",
                   "a,a,a,a",
                   "b"])
        .ExpectsResult(11)
        .WithTheActualSolutionBeing(6799);

    public override Puzzle PartTwo => PuzzleBuilder
        .FromInput(["abc",
                    "",
                    "a",
                    "b",
                    "c",
                    "",
                    "ab",
                    "ac",
                    "",
                    "a",
                    "a",
                    "a",
                    "a",
                    "",
                    "b"])
        .ParsedAs(["abc",
                   "a,b,c",
                   "ab,ac",
                   "a,a,a,a",
                   "b"])
        .ExpectsResult(6)
        .WithTheActualSolutionBeing(3354);
}
