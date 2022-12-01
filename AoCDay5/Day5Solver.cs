using System;
using System.Linq;
using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers.AoCDay5;

public class Day5Solver
{
    private string _partOnePassword = "";
    private readonly string[] _text;
    private string _inputWithIterator = "";
    private int _iterator;
    private string _leadingZeroes = "";
    private readonly char[] _partTwoPassword = new char[8];
    private readonly bool[] _partTwoPasswordMonitor = new bool[8];

    public Day5Solver()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.Read("../../../AoCDay5/input.txt");
        _text = rawText.ToArray();
        Array.Fill(_partTwoPasswordMonitor, false);
    }

    public void SolvePartOne()
    {
        var inputString = _text[0];
        foreach (var t in inputString)
        {
            var hashResult = "";
            do
            {
                _inputWithIterator = inputString + Convert.ToString(_iterator);
                hashResult = Md5Hasher.hashIt(_inputWithIterator);
                _leadingZeroes = hashResult.Substring(0, 5);
                _iterator++;
            } while (_leadingZeroes != "00000");

            _partOnePassword += hashResult[5];
        }

        Console.WriteLine(_partOnePassword);
    }

    public void SolvePartTwo()
    {
        var inputString = _text[0];
        while (_partTwoPasswordMonitor.Any(p => p == false))
        {
            var hashResult = "";
            do
            {
                _inputWithIterator = inputString + Convert.ToString(_iterator);
                hashResult = Md5Hasher.hashIt(_inputWithIterator);
                _leadingZeroes = hashResult[..5];
                _iterator++;
            } while (_leadingZeroes != "00000");

            var indexToModify = (int)char.GetNumericValue(hashResult[5]);
            if (indexToModify is >= 8 or <= -1 || _partTwoPasswordMonitor[indexToModify]) continue;
            _partTwoPassword[indexToModify] = hashResult[6];
            _partTwoPasswordMonitor[indexToModify] = true;
        }

        foreach (var letter in _partTwoPassword) Console.Write(letter);
    }
}