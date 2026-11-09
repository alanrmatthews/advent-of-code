using System.Text.RegularExpressions;

using AdventOfCode.Commons;

namespace AdventOfCode.Y2020.Day8;

/// <summary>
/// Advent of Code 2020, Day 8: Handheld Halting.
/// The input is a list of instructions for a handheld game console.
/// Part One asks for the value of the accumulator before any instruction is executed a second time.
/// Part Two asks for the value of the accumulator after the program terminates correctly.
/// </summary>
public sealed class Solver()
    : Solver<string[], int>(inputPath: "input.txt")
{
    public override int PartOne(string[] input)
    {
        var emulator = new Emulator(input);
        emulator.run();
        return emulator.Accumulator;
    }

    public override int PartTwo(string[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            var modifiedInstructions = (string[])input.Clone();
            if (modifiedInstructions[i].StartsWith("nop"))
                modifiedInstructions[i] = modifiedInstructions[i].Replace("nop", "jmp");
            else if (modifiedInstructions[i].StartsWith("jmp"))
                modifiedInstructions[i] = modifiedInstructions[i].Replace("jmp", "nop");
            else
                continue;

            var emulator = new Emulator(modifiedInstructions);
            emulator.run();
            if (emulator.Terminated)
                return emulator.Accumulator;
        }

        return -1;
    }

    public override string[] ParseInput(IEnumerable<string> input)
        => [.. input.Select(line => line)];


    private class Emulator(string[] instructions)
    {
        private readonly string[] instructions = instructions;
        public int Accumulator { get; private set; } = 0;
        public int Pointer { get; private set; } = 0;
        private readonly HashSet<int> visited = new HashSet<int>();


        public void run()
        {
            while (!visited.Contains(Pointer) && Pointer != instructions.Count())
            {
                visited.Add(Pointer);
                var operation = instructions[Pointer][..3];
                var argument = int.Parse(instructions[Pointer][4..]);
                switch (operation)
                {
                case "nop":
                    Pointer++;
                    break;
                case "acc":
                    Accumulator += argument;
                    Pointer++;
                    break;
                case "jmp":
                    Pointer += argument;
                    break;
                default:
                    throw new InvalidOperationException($"Unknown operation: {operation}");
                }
            }
        }

        public bool Terminated => Pointer == instructions.Count();
    }
}
