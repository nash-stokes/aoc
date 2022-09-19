using AoCProblemSolvers.Utilities;
namespace AoCDay4;

public class Day4Solver
{
    private FileReader _fileReader;
    private IEnumerable<string> _rawText;
    private string[] _text;
    private SortedDictionary<char, int> _letterRegistry = new();

    public Day4Solver()
    {
        _fileReader = new FileReader();
        _rawText = _fileReader.Read("../../../AoCDay4/input.txt");
        _text = _rawText.ToArray();
    }

    public void SolvePartOne()
    {
        int sum = 0;
        foreach (var line in _text)
        {
            List<string> charStringsRaw = new List<string>(line.Split('-'));
            string? judgmentString = charStringsRaw.LastOrDefault();
            int sectorId = Convert.ToInt32(judgmentString.Split('[').ElementAt(0));
            string judgmentCharacters = judgmentString.Split('[').ElementAt(1).Trim(']');
            charStringsRaw.Remove(judgmentString);
            //iterate over each string
            UpdateRegistry(charStringsRaw);
            if (stringTest(judgmentCharacters))
            {
                sum += sectorId;
            }
            _letterRegistry.Clear();
        }
        Console.WriteLine(sum);
    }

    private bool stringTest(string judgmentCharacters)
    {
        
        IEnumerable<char> sortedString = _letterRegistry.Keys.Take(5);
        foreach (var letter in _letterRegistry)
        {
            Console.Write(letter);
        }
        Console.WriteLine();
        for (var index = 0; index < judgmentCharacters.Length; index++)
        {
            var letter = judgmentCharacters[index];
            if (letter != sortedString.ElementAt(index))
            {
                return false;
            }
        }

        return true;
    }

    private void UpdateRegistry(List<string> charStringsRaw)
    {
        foreach (var charString in charStringsRaw)
        {
            //iterate over each character
            foreach (var character in charString)
            {
                if (_letterRegistry.Any(c => c.Key == character))
                {
                    _letterRegistry[character]++;
                }
                else
                {
                    _letterRegistry.Add(character, 1);
                }
            }
        }
    }
}