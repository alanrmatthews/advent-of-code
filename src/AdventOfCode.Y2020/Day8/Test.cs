using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day8;

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
        .FromInput(["nop +0",
                    "acc +1",
                    "jmp +4",
                    "acc +3",
                    "jmp -3",
                    "acc -99",
                    "acc +1",
                    "jmp -4",
                    "acc +6"])
        .ParsedAs(["nop +0",
                   "acc +1",
                   "jmp +4",
                   "acc +3",
                   "jmp -3",
                   "acc -99",
                   "acc +1",
                   "jmp -4",
                   "acc +6"])
        .ExpectsResult(5)
        .WithTheActualSolutionBeing(2034);

    public override Puzzle PartTwo => PuzzleBuilder
        .FromInput(["nop +0",
                    "acc +1",
                    "jmp +4",
                    "acc +3",
                    "jmp -3",
                    "acc -99",
                    "acc +1",
                    "jmp -4",
                    "acc +6"])
        .ParsedAs(["nop +0",
                   "acc +1",
                   "jmp +4",
                   "acc +3",
                   "jmp -3",
                   "acc -99",
                   "acc +1",
                   "jmp -4",
                   "acc +6"])
        .ExpectsResult(8)
        .WithTheActualSolutionBeing(672);
}
