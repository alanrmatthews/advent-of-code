using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day11;

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
        .FromInput(["L.LL.LL.LL",
                    "LLLLLLL.LL",
                    "L.L.L..L..",
                    "LLLL.LL.LL",
                    "L.LL.LL.LL",
                    "L.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLLL",
                    "L.LLLLLL.L",
                    "L.LLLLL.LL"])
        .ParsedAs(["L.LL.LL.LL",
                    "LLLLLLL.LL",
                    "L.L.L..L..",
                    "LLLL.LL.LL",
                    "L.LL.LL.LL",
                    "L.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLLL",
                    "L.LLLLLL.L",
                    "L.LLLLL.LL"])
        .ExpectsResult(37)
        .WithTheActualSolutionBeing(2183);

    public override Puzzle PartTwo => PuzzleBuilder
        .FromInput(["L.LL.LL.LL",
                    "LLLLLLL.LL",
                    "L.L.L..L..",
                    "LLLL.LL.LL",
                    "L.LL.LL.LL",
                    "L.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLLL",
                    "L.LLLLLL.L",
                    "L.LLLLL.LL"])
        .ParsedAs(["L.LL.LL.LL",
                    "LLLLLLL.LL",
                    "L.L.L..L..",
                    "LLLL.LL.LL",
                    "L.LL.LL.LL",
                    "L.LLLLL.LL",
                    "..L.L.....",
                    "LLLLLLLLLL",
                    "L.LLLLLL.L",
                    "L.LLLLL.LL"])
        .ExpectsResult(26)
        .WithTheActualSolutionBeing(1990);
}
