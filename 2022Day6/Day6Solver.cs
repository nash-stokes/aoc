using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers._2022Day6;

public class Day6Solver
{
    private FileReader _fileReader;
    private IEnumerable<string> _rawText;
    private readonly string[] _text;
    
    public Day6Solver()
    {
        _fileReader = new FileReader();
        _rawText = _fileReader.Read("../../../2022Day6/input.txt");
        _text = _rawText.ToArray();
    }

    public void SolvePartOne()
    {
        var importantString = _text[0];
        for (int i = 0; i < importantString.Length - 3; i++)
        {
            var charactersHash = new HashSet<char>();
            char first = importantString[i];
            charactersHash.Add(first);
            char second = importantString[i + 1];
            if (!charactersHash.Contains(second))
            {
                charactersHash.Add(second);
            }
            else
            {
                continue;
            }
            char third = importantString[i + 2];
            if (!charactersHash.Contains(third))
            {
                charactersHash.Add(third);
            }
            else
            {
                continue;
            }
            char fourth = importantString[i + 3];
            if (!charactersHash.Contains(fourth))
            {
                Console.WriteLine(i + 3);
                break;
            }
        }
    }
    
    public void SolvePartTwo()
    {
        var importantString = _text[0];
        
        for (int i = 0; i < importantString.Length - 14; i++)
        {
            var hashSet = new HashSet<char>();
            for (int j = 0; j < 14; j++)
            {
                char nextChar = importantString[i + j];
                if (!hashSet.Contains(nextChar))
                {
                    hashSet.Add(nextChar);
                }
                else
                {
                    break;
                }
            }

            if (hashSet.Count != 14) continue;
            Console.WriteLine(i + 1);
            break;
        }
    }
}