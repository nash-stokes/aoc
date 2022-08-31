using AoCProblemSolvers.Utilities;
namespace AoCDay4;

public class Day4Solver
{
    private FileReader _fileReader;
    private IEnumerable<string> _rawText;
    private string[] _text; 
    
    public Day4Solver()
    {
        _fileReader = new FileReader();
        _rawText = _fileReader.read("../../../AoCDay4/input.txt");
        _text = _rawText.ToArray();
    }
    public void SolvePartOne()
    {
        foreach(var line in text)
        {
            var dimensions = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var side1 = Int32.Parse(dimensions[0]);
            var side2 = Int32.Parse(dimensions[1]);
            var side3 = Int32.Parse(dimensions[2]);
            if (side1 < side2 + side3 && side2 < side1 + side3 && side3 < side1 + side2)
            {
                _validTriangleCounter++;
            }
        }
        Console.WriteLine(_validTriangleCounter.ToString());
    }