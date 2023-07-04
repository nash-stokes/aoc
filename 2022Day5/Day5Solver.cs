using System.Collections;
using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers._2022Day5;

public class Day5Solver
{
    private FileReader _fileReader;
    private IEnumerable<string> _rawText;
    private readonly string[] _text;
    private readonly List<int[]> _instructionsList = new ();
    private List<Stack<char>> _stacks;
        private string[] strings = { "mjcbfrlh", "zcd", "hjfcngw", "pjdmtsb", "ncdrj", "wldqpjgz", "pztfrh", "lvmg", "cbgpfqrj" };

    public Day5Solver()
    {
        _fileReader = new FileReader();
        _rawText = _fileReader.Read("../../../2022Day5/input.txt");
        _text = _rawText.ToArray();
        _stacks = new List<Stack<char>>();
    }

    public void SolvePartOne()
    {
        for (var i = 0; i < 9; i++)
        {
            _stacks.Add(new Stack<char>());
            foreach (var character in strings[i])
            {
                _stacks[i].Push(character);
            }
        }
        ConvertRawTextToStrings();
        ExecuteInstructions();
        PrintOutputText();
    }
    
    private void PrintOutputText()
    {
        foreach (var stack in _stacks)
        {
            if (stack.Count > 0)
            {
                Console.Write(stack.Peek());
            }
        }
    }

    private void ExecuteInstructions()
    {
        foreach (var instruction in _instructionsList)
        {
            var numberOfCrates = instruction[0];
            Console.Write(numberOfCrates + " ");
            var sourceStack = instruction[1] - 1;
            Console.Write(sourceStack + " ");
            var destinationStack = instruction[2] - 1;
            Console.Write(destinationStack + " ");
            for (var i = 0; i < numberOfCrates; i++)
            {
                if (_stacks[sourceStack].Count <= 0) continue;
                var crate = _stacks[sourceStack].Pop();
                _stacks[destinationStack].Push(crate);
            }
            Console.WriteLine();
        }
    }

    public void SolvePartTwo()
    {
       
    }
    
    public void ConvertRawTextToStrings()
    {
        foreach (var t in _text)
        {
            var instructions = t.Split(' ');
            _instructionsList.Add(new[] {Convert.ToInt32(instructions[1]),
                Convert.ToInt32(instructions[3]),
                Convert.ToInt32(instructions[5])
            });
        }
    }
}