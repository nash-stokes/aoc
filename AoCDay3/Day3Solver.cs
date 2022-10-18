using AoCProblemSolvers.Utilities;

namespace AoCDay3;

public class Day3Solver
{
    private int _validTriangleCounter = 0;

    public void SolvePartOne()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.Read("../../../AoCDay3/input.txt");
        var text = rawText.ToArray();
        foreach (var line in text)
        {
            var dimensions = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var side1 = int.Parse(dimensions[0]);
            var side2 = int.Parse(dimensions[1]);
            var side3 = int.Parse(dimensions[2]);
            if (side1 < side2 + side3 && side2 < side1 + side3 && side3 < side1 + side2) _validTriangleCounter++;
        }

        Console.WriteLine(_validTriangleCounter.ToString());
    }

    public void SolvePartTwo()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.Read("../../../AoCDay3/input.txt");
        var text = rawText.ToArray();
        var dimensions = new List<int>();
        foreach (var line in text)
        {
            var rawDimensions = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            //Cleaner way to do this?
            dimensions.Add(int.Parse(rawDimensions[0]));
            dimensions.Add(int.Parse(rawDimensions[1]));
            dimensions.Add(int.Parse(rawDimensions[2]));
        }

        //Should I have used a 3 by dynamic number array?
        for (var i = 0; i < dimensions.Count; i = i + 9)
        for (var j = 0; j < 3; j++)
        {
            var side1 = dimensions.ElementAt(j + i);
            var side2 = dimensions.ElementAt(j + i + 3);
            var side3 = dimensions.ElementAt(j + i + 6);
            if (side1 < side2 + side3 && side2 < side1 + side3 && side3 < side1 + side2) _validTriangleCounter++;
        }

        Console.WriteLine("Number of valid triangles: " + _validTriangleCounter);
    }
}