using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day2;

/// <summary>
/// Example of how to test the <see cref="Solver{TInput, TResult}"/>
///
/// For each part of the puzzle, we can specify what the example is and what solution it as, along with the
/// expected solution for our puzzle input
/// </summary>
public sealed class LocalInputSolverTest
    : TestEngine<Solver, PasswordEntry[], int>
{
    public override Puzzle PartOne => PuzzleBuilder
        .FromInput(["1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc"])
        .ParsedAs([
            new PasswordEntry(1, 3, 'a', "abcde"),
            new PasswordEntry(1, 3, 'b', "cdefg"),
            new PasswordEntry(2, 9, 'c', "ccccccccc")
        ])
        .ExpectsResult(2)
        .WithTheActualSolutionBeing(524);

    public override Puzzle PartTwo => PuzzleBuilder
        .FromInput(["1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc"])
        .ParsedAs([
            new PasswordEntry(1, 3, 'a', "abcde"),
            new PasswordEntry(1, 3, 'b', "cdefg"),
            new PasswordEntry(2, 9, 'c', "ccccccccc")
        ])
        .ExpectsResult(1)
        .WithTheActualSolutionBeing(485);
}
