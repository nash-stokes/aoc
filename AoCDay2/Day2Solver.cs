using AoCProblemSolvers.Utilities;

namespace AoCDay2;

public class Day2Solver
{
    //Difference between const and static
    private static readonly char[,] Dialpad = new char[5, 5] { {'0', '0', '1','0','0'},{'0','2','3','4','0'},
        {'5','6','7','8','9'},{'0','A','B','C', '0'}, {'0','0','D', '0', '0' }};
    private int _currX = 0;
    private int _currY = 2;
    private string _bathroomCode;
    public void SolvePartTwo()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.Read("../../../AoCDay2/input.txt");
        var text = rawText.ToArray();
        foreach(string line in text)
        {
            foreach (char direction in line)
            {
                ShiftNumber(direction);
            }
            _bathroomCode += Dialpad[_currY, _currX];
        }
        Console.WriteLine("Final number: " + _bathroomCode);
    }

    private void ShiftNumber(char direction)
    {
        switch (direction)
        {
            case 'U':
                UpMovement();
                break;
            case 'D':
                DownMovement();
                break;
            case 'L':
                LeftMovement();
                break;
            case 'R':
                RightMovement();
                break;
            default:
                break;
        }
    }

    private void UpMovement()
    {
        if (_currY > 0)
        {
            if (Dialpad[_currY - 1, _currX] != '0')
            {
                _currY--;
            }
        }
    }

    private void DownMovement()
    {
        if (_currY < 4)
        {
            if (Dialpad[_currY + 1, _currX] != '0')
            {
                _currY++;
            }
        }
    }

    private void LeftMovement()
    {
        if (_currX > 0)
        {
            if (Dialpad[_currY, _currX - 1] != '0')
            {
                _currX--;
            }
        }
    }

    private void RightMovement()
    {
        if (_currX < 4)
        {
            if (Dialpad[_currY, _currX + 1] != '0')
            {
                _currX++;
            }
        }
    }
}