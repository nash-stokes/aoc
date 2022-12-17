using AoCProblemSolvers.Utilities;
using System.Text;

namespace AoCProblemSolvers.AoCDay5;

public class Day5Solver
{
    private FileReader _fileReader;
    private IEnumerable<string> _rawText;
    private string[] _text;
    private string? hashResult;
    private string partOnePassword = "";
    private char[] partTwoPassword = new char[8];
    private bool[] partTwoPasswordMonitor = new bool[8];
    private int iterator = 0;
    private string leadingZeroes = "";
    private string inputWithIterator = "";

    public Day5Solver()
    {
        _fileReader = new FileReader();
        _rawText = _fileReader.Read("../../../AoCDay5/input.txt");
        _text = _rawText.ToArray();
        Array.Fill(partTwoPasswordMonitor, false);
    }

    public void SolvePartOne()
    {
        string inputString = _text[0];
        foreach (var t in inputString)
        {
            do
            {
                inputWithIterator = inputString + (Convert.ToString(iterator));
                hashResult = Md5Hasher.hashIt(inputWithIterator);
                if (hashResult != null) leadingZeroes = hashResult.Substring(0, 5);
                iterator++;
            }
            while (leadingZeroes != "00000");

            if (hashResult != null) partOnePassword += hashResult[5];
        }
        Console.WriteLine(partOnePassword);
    }

    public void SolvePartTwo()
    {
        string inputString = _text[0];
        while(partTwoPasswordMonitor.Any(p => p == false)) { 
            do
            {
                inputWithIterator = inputString + (Convert.ToString(iterator));
                hashResult = Md5Hasher.hashIt(inputWithIterator);
                leadingZeroes = hashResult.Substring(0, 5);
                iterator++;
            }
            while (leadingZeroes != "00000");
            int indexToModify = (int)Char.GetNumericValue(hashResult[5]);
            if (indexToModify < 8 && indexToModify > -1 && partTwoPasswordMonitor[indexToModify] == false) {
                partTwoPassword[indexToModify] = hashResult[6];
                partTwoPasswordMonitor[indexToModify] = true;
            }
        }
        foreach(var letter in partTwoPassword)
        {
            Console.Write(letter);
        }
    }
}