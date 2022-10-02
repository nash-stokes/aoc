using AoCProblemSolvers.Utilities;
namespace AoCDay4;

public class Day4Solver
{
    private FileReader _fileReader;
    private IEnumerable<string> _rawText;
    private string[] _text;
    private Dictionary<char, int> _letterRegistry = new();
    private int _letterShift = 0;
    private List<string> realLocations = new List<string>();
    private bool targetRoom = false;

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
            //split the line by dashes
            List<string> charStringsRaw = new List<string>(line.Split('-'));
            //get the character string at the end
            string? judgmentString = charStringsRaw.LastOrDefault();
            //get the sectorid
            int sectorId = Convert.ToInt32(judgmentString.Split('[').ElementAt(0));
            //strip the brackets
            string judgmentCharacters = judgmentString.Split('[').ElementAt(1).Trim(']');
            //remove the sectorid and final character string from major string
            charStringsRaw.Remove(judgmentString);
            //iterate over each string
            UpdateRegistryValues(charStringsRaw);
            if (stringTest(judgmentCharacters))
            {
                sum += sectorId;
                realLocations.Add(line);
            }
            _letterRegistry.Clear();
        }
        Console.WriteLine(sum);
    }

    public void SolvePartTwo()
    {
        
        foreach (var line in realLocations)
        {
            //split the line by dashes
            List<string> charStringsRaw = new List<string>(line.Split('-'));

            //get the character string at the end
            string? judgmentString = charStringsRaw.LastOrDefault();

            //get the sectorid
            int sectorId = Convert.ToInt32(judgmentString.Split('[').ElementAt(0));

            //get remainder after dividing by 26
            _letterShift = sectorId % 26;

            //remove the sectorid and final character string from major string
            charStringsRaw.Remove(judgmentString);

            //iterate over each string
            getShiftedStrings(charStringsRaw);

            if (targetRoom)
            {
                Console.WriteLine($"{sectorId} \n");
                targetRoom = false;
            }
        }
    }

    public void getShiftedStrings(List<String> unshiftedStrings)
    {
        foreach (var unshiftedString in unshiftedStrings)
        {
            string shiftedString = "";
            foreach(var character in unshiftedString)
            {
                var characterAsInt = (int)character;
                var shiftedCharAsInt = characterAsInt + _letterShift;
                if (shiftedCharAsInt > 122)
                {
                    shiftedCharAsInt = 96 + (shiftedCharAsInt % 122);
                }
                shiftedString += (char)(shiftedCharAsInt);
                if (shiftedString.Equals("north"))
                {
                    targetRoom = true;
                }
            }
            
        }
    }
    private bool stringTest(string judgmentCharacters)
    {
        var sortedRegistry = _letterRegistry.OrderByDescending(x => x.Value).ThenBy(k => k.Key).Select(k=> k.Key).Take(5);

        for (var index = 0; index < judgmentCharacters.Length; index++)
        {
            var letter = judgmentCharacters[index];
            if (letter != sortedRegistry.ElementAt(index))
            {
                return false;
            }
        }
        return true;
    }

    private void UpdateRegistryValues(List<string> charStringsRaw)
    {
        foreach (var charString in charStringsRaw)
        {
            //iterate over each character
            foreach (var character in charString)
            {
                //increment count if character already seen
                if (_letterRegistry.Any(c => c.Key == character))
                {
                    _letterRegistry[character]++;
                }
                //add new character to registry
                else
                {
                    _letterRegistry.Add(character, 1);
                }
            }
        }
    }
}