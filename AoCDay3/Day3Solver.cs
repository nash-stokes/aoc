using AoCProblemSolvers.Utilities;
namespace AoCDay3;

public class Day3Solver
{
    private int _validTriangleCounter = 0;
    public void SolvePartOne()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.read("../../../AoCDay3/input.txt");
        var text = rawText.ToArray();
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

}