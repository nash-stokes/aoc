using AoCProblemSolvers.Utilities;

namespace AoCDay2;

public class Day2Solver
{
    //Difference between const and static
    private static readonly char[,] _dialpad = new char[5, 5] { {'0', '0', '1','0','0'},{'0','2','3','4','0'},
        {'5','6','7','8','9'},{'0','A','B','C', '0'}, {'0','0','D', '0', '0' }};
    private int _currX = 0;
    private int _currY = 2;
    private string _bathroomCode;
    public void SolvePartTwo()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.read("../../../AoCDay2/input.txt");
        var text = rawText.ToArray();
        foreach(string line in text)
        {
            foreach (char direction in line)
            {
                shiftNumber(direction);
            }
            _bathroomCode += _dialpad[_currY, _currX];
        }
        Console.WriteLine("Final number: " + _bathroomCode);
    }

    private void shiftNumber(char direction)
    {
        switch (direction)
        {
            case 'U':
                upMovement();
                break;
            case 'D':
                downMovement();
                break;
            case 'L':
                leftMovement();
                break;
            case 'R':
                rightMovement();
                break;
            default:
                break;
        }
    }

    private void upMovement()
    {
        if (_currY > 0)
        {
            if (_dialpad[_currY - 1, _currX] != '0')
            {
                _currY--;
            }
        }
    }

    private void downMovement()
    {
        if (_currY < 4)
        {
            if (_dialpad[_currY + 1, _currX] != '0')
            {
                _currY++;
            }
        }
    }

    private void leftMovement()
    {
        if (_currX > 0)
        {
            if (_dialpad[_currY, _currX - 1] != '0')
            {
                _currX--;
            }
        }
    }

    private void rightMovement()
    {
        if (_currX < 4)
        {
            if (_dialpad[_currY, _currX + 1] != '0')
            {
                _currX++;
            }
        }
    }
}