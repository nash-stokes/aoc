using AoCProblemSolvers.Utilities;

namespace AoCDay1;

public class Day1Solver
{
    private coords _coords = new (0, 0);
    private direction _facing = direction.North;
    private readonly HashSet<coords> _coordsSet = new ();
    private bool doubleVisitFound = false;
    public void SolvePartOne()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.read("../../../AoCDay1/input.txt");
        var text = rawText.ToArray().ElementAt(0);
        string[] directions = text.Split();
        foreach (var direction in directions)
        {
            if (doubleVisitFound)
            {
                break;
            }
            DirectionToMovement(direction);
            Console.WriteLine("Final position: " + _coords.X + "," + _coords.Y);
        }
        
        int distance = Math.Abs(_coords.X) + Math.Abs(_coords.Y);
        Console.WriteLine("Final distance from origin: {0} blocks", distance);
    }
    private void DirectionToMovement(string turnDirection)
    {
        int.TryParse(turnDirection[1..], out var numberOfBlocks);
        if (turnDirection[0] == 'L')
        {
            _facing = _facing switch
            {
                direction.North => direction.West,
                direction.East => direction.North,
                direction.South => direction.East,
                direction.West => direction.South,
                _ => _facing
            };
            Console.WriteLine("Turning Left");
        }
        else
        {
            _facing = _facing switch
            {
                direction.North => direction.East,
                direction.East => direction.South,
                direction.South => direction.West,
                direction.West => direction.North,
                _ => _facing
            };
            Console.WriteLine("Turning Right");
        }
        BlockShiftHandler(numberOfBlocks);
    }

    private void BlockShiftHandler(int blocks)
    {
        switch (_facing)
        {
            case direction.North:
                walkNorth(blocks);
                break;
            case direction.East:
                walkEast(blocks);
                break;
            case direction.South:
                walkSouth(blocks);
                break;
            case direction.West:
                walkWest(blocks);
                break;
        }
    }

    private void walkNorth(int blocks)
    {
        for(int i = 0; i < blocks; i++)
        {
            _coords.Y++;
            var currentCoord = new coords(_coords.X, _coords.Y);
            if (_coordsSet.Contains(currentCoord))
            {
                int distance = Math.Abs(_coords.X) + Math.Abs(_coords.Y);
                Console.WriteLine("DOUBLE HIT THIS FAR AWAY: " + distance);
                doubleVisitFound = true;
            }
            else
            {
                _coordsSet.Add(currentCoord);
            }
        }
    }
    private void walkEast(int blocks)
    {
        for(int i = 0; i < blocks; i++)
        {
            _coords.X++;
            var currentCoord = new coords(_coords.X, _coords.Y);
            if (_coordsSet.Contains(currentCoord))
            {
                int distance = Math.Abs(_coords.X) + Math.Abs(_coords.Y);
                Console.WriteLine("DOUBLE HIT THIS FAR AWAY: " + distance);
                doubleVisitFound = true;

            }
            else
            {
                _coordsSet.Add(currentCoord);
            }
        }
    }
    private void walkWest(int blocks)
    {
        for(int i = 0; i < blocks; i++)
        {
            _coords.X--;
            var currentCoord = new coords(_coords.X, _coords.Y);
            if (_coordsSet.Contains(currentCoord))
            {
                int distance = Math.Abs(_coords.X) + Math.Abs(_coords.Y);
                Console.WriteLine("DOUBLE HIT THIS FAR AWAY: " + distance);
                doubleVisitFound = true;
            }
            else
            {
                _coordsSet.Add(currentCoord);
            }
        }
    }
    private void walkSouth(int blocks)
    {
        for(int i = 0; i < blocks; i++)
        {
            _coords.Y--;
            var currentCoord = new coords(_coords.X, _coords.Y);
            if (_coordsSet.Contains(currentCoord))
            {
                int distance = Math.Abs(_coords.X) + Math.Abs(_coords.Y);
                Console.WriteLine("DOUBLE HIT THIS FAR AWAY: " + distance);
                doubleVisitFound = true;
            }
            else
            {
                _coordsSet.Add(currentCoord);
            }
        }
    }

    struct coords
    {
        public int X;
        public int Y;

        public coords(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public enum direction
    {
        North,
        East,
        South,
        West
    }
}