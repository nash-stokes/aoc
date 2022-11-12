using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers.AoCDay5;

public class Day5Solver
{
    private FileReader _fileReader;
    private IEnumerable<string> _rawText;
    private string[] _text;
    private string hashResult;
    private string password = "";
    private int iterator = 0;
    private string leadingZeroes = "";
    private string inputWithZeroes = "";

    public Day5Solver()
    {
        _fileReader = new FileReader();
        _rawText = _fileReader.Read("../../../AoCDay5/input.txt");
        _text = _rawText.ToArray();
    }

    public void SolvePartOne()
    {
        string inputString = _text[0];
        for(int i = 0; i < inputString.Length; i++)
        {
            inputWithZeroes = inputString + (Convert.ToString(iterator));
            hashResult = Md5Hasher.hashIt(inputString);
            leadingZeroes = hashResult.Substring(0, 5);
            do
            {
                inputWithZeroes = inputString + (Convert.ToString(iterator));
                hashResult = Md5Hasher.hashIt(inputString);
                leadingZeroes = hashResult.Substring(0, 5);
                iterator++;
            }
            while (leadingZeroes != "00000");
            Console.WriteLine(hashResult);
            password.Append(hashResult[5]);
        }
        Console.WriteLine(password);
    }
}