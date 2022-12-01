using System;
using System.Linq;
using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers._2022Day1;

public class Day1Solver
{
    public void SolvePartOne()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.Read("../../../2022Day1/input.txt");
        int sum = 0;
        List<int> caloriesList = new();
        foreach (var item in rawText)
        {
            if (item != "")
            {
                sum += Int32.Parse(item);
            }
            else
            {
                caloriesList.Add(sum);
                sum = 0;
            }
        }
        Console.Write(caloriesList.Max());
    }
    public void SolvePartTwo()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.Read("../../../2022Day1/input.txt");
        int sum = 0;
        List<int> caloriesList = new();
        foreach (var item in rawText)
        {
            if (item != "")
            {
                sum += Int32.Parse(item);
            }
            else
            {
                caloriesList.Add(sum);
                sum = 0;
            }
        }

        sum = 0;
        for (var i = 0; i < 3; i++)
        {
            var currentMax = caloriesList.Max();
            sum += currentMax;
            caloriesList.Remove(currentMax);
        }
        Console.Write(sum);
    }
}