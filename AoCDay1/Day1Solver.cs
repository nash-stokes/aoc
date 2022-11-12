using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers.AoCDay1;

public class Day1Solver
{
    private Coords _coords = new(0, 0);
    private Direction _facing = Direction.North;
    private readonly HashSet<Coords> _coordsSet = new();
    private bool _doubleVisitFound = false;

    public void SolvePartOne()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.Read("../../../AoCDay1/input.txt");
        var text = rawText.ToArray().ElementAt(0);
        var directions = text.Split();
        foreach (var direction in directions)
        {
            if (_doubleVisitFound) break;
            DirectionToMovement(direction);
            Console.WriteLine("Final position: " + _coords.X + "," + _coords.Y);
        }

        var distance = Math.Abs(_coords.X) + Math.Abs(_coords.Y);
        Console.WriteLine("Final distance from origin: {0} blocks", distance);
    }

    private void DirectionToMovement(string turnDirection)
    {
        int.TryParse(turnDirection[1..], out var numberOfBlocks);
        if (turnDirection[0] == 'L')
        {
            _facing = _facing switch
            {
                Direction.North => Direction.West,
                Direction.East => Direction.North,
                Direction.South => Direction.East,
                Direction.West => Direction.South,
                _ => _facing
            };
            Console.WriteLine("Turning Left");
        }
        else
        {
            _facing = _facing switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
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
            case Direction.North:
                WalkNorth(blocks);
                break;
            case Direction.East:
                WalkEast(blocks);
                break;
            case Direction.South:
                WalkSouth(blocks);
                break;
            case Direction.West:
                WalkWest(blocks);
                break;
        }
    }

    private void WalkNorth(int blocks)
    {
        for (var i = 0; i < blocks; i++)
        {
            _coords.Y++;
            var currentCoord = new Coords(_coords.X, _coords.Y);
            if (_coordsSet.Contains(currentCoord))
            {
                var distance = Math.Abs(_coords.X) + Math.Abs(_coords.Y);
                Console.WriteLine("DOUBLE HIT THIS FAR AWAY: " + distance);
                _doubleVisitFound = true;
            }
            else
            {
                _coordsSet.Add(currentCoord);
            }
        }
    }

    private void WalkEast(int blocks)
    {
        for (var i = 0; i < blocks; i++)
        {
            _coords.X++;
            var currentCoord = new Coords(_coords.X, _coords.Y);
            if (_coordsSet.Contains(currentCoord))
            {
                var distance = Math.Abs(_coords.X) + Math.Abs(_coords.Y);
                Console.WriteLine("DOUBLE HIT THIS FAR AWAY: " + distance);
                _doubleVisitFound = true;
            }
            else
            {
                _coordsSet.Add(currentCoord);
            }
        }
    }

    private void WalkWest(int blocks)
    {
        for (var i = 0; i < blocks; i++)
        {
            _coords.X--;
            var currentCoord = new Coords(_coords.X, _coords.Y);
            if (_coordsSet.Contains(currentCoord))
            {
                var distance = Math.Abs(_coords.X) + Math.Abs(_coords.Y);
                Console.WriteLine("DOUBLE HIT THIS FAR AWAY: " + distance);
                _doubleVisitFound = true;
            }
            else
            {
                _coordsSet.Add(currentCoord);
            }
        }
    }

    private void WalkSouth(int blocks)
    {
        for (var i = 0; i < blocks; i++)
        {
            _coords.Y--;
            var currentCoord = new Coords(_coords.X, _coords.Y);
            if (_coordsSet.Contains(currentCoord))
            {
                var distance = Math.Abs(_coords.X) + Math.Abs(_coords.Y);
                Console.WriteLine("DOUBLE HIT THIS FAR AWAY: " + distance);
                _doubleVisitFound = true;
            }
            else
            {
                _coordsSet.Add(currentCoord);
            }
        }
    }

    private struct Coords
    {
        public int X;
        public int Y;

        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}