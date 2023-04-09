using System;
using System.Linq;
using System.Runtime.CompilerServices;
using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers._2022Day1;

public class Day1Solver
{
    private readonly FileReader _fileReader;

    private readonly IEnumerable<string> _rawText;
    private readonly string[] _text;

    public Day1Solver()
    {
        _fileReader = new FileReader();
        _rawText = _fileReader.Read("../../../2022Day1/input.txt");
        _text = _rawText.ToArray();
    }
    public void SolvePartOne()
    {
        var sum = 0;
        var max = 0;
        foreach(var line in _text)
        {
            if (string.IsNullOrWhiteSpace(line)) { 
                if (sum > max)
                {
                    max = sum;
                }
                sum = 0;
            }
            else
            {
                sum += int.Parse(line);
            }
        }
        Console.WriteLine("Max calories: " + max);
    }

    public void SolvePartTwo()
    {
        var sum = 0;
        var max = 0;
        var two = 0;
        var three = 0;
        foreach (var line in _text)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (sum > max)
                {
                    three = two;
                    two = max;
                    max = sum;
                }
                else if(sum > two)
                {
                    three = two;
                    two = sum;
                }
                else if(sum > three)
                {
                    three = sum;
                }
                sum = 0;
            }
            else
            {
                sum += int.Parse(line);
            }
        }
        Console.WriteLine("Top three calories: " + (max + two + three));
    }

}