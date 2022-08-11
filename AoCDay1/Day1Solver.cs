using AoCDay1.Utilities;

namespace AoCDay1;

public class Day1Solver
{
    private coords _coords = new coords(0, 0);
    public direction facing = direction.North;
    public void SolvePartOne()
    {
        var fileReader = new FileReader();
        var rawText = fileReader.read("../../../AoCDay1/input.txt");
        var text = rawText.ToArray().ElementAt(0);
        string[] directions = text.Split(", ");
        foreach (var direction in directions)
        {
            Console.WriteLine("Initial position: " + _coords.X + "," + _coords.Y);
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
            facing = facing switch
            {
                direction.North => direction.West,
                direction.East => direction.North,
                direction.South => direction.East,
                direction.West => direction.South,
                _ => facing
            };
            Console.WriteLine("Turning Left");
        }
        else
        {
            facing = facing switch
            {
                direction.North => direction.East,
                direction.East => direction.South,
                direction.South => direction.West,
                direction.West => direction.North,
                _ => facing
            };
            Console.WriteLine("Turning Right");
        }
        BlockShiftHandler(numberOfBlocks);
    }

    private void BlockShiftHandler(int blocks)
    {
        switch (facing)
        {
            case direction.North:
                _coords.Y += blocks;
                break;
            case direction.East:
                _coords.X += blocks;
                break;
            case direction.South:
                _coords.Y -= blocks;
                break;
            case direction.West:
                _coords.X -= blocks;
                break;
        }
    }

    struct coords
    {
        public int X;
        public int Y;
        public int counter;

        public coords(int x, int y)
        {
            X = x;
            Y = y;
            counter = 0;
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