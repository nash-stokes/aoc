using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers._2022Day7;

public class Day7Solver
{
    private FileReader? _fileReader;
    private IEnumerable<string>? _rawText;
    private readonly string[] _text;
    private Node _currNode;
    private DirectoryTree _directoryTree;

    public Day7Solver()
    {
        _fileReader = new FileReader();
        _rawText = _fileReader.Read("../../../2022Day7/input.txt");
        _text = _rawText.ToArray();
        _currNode = new Node();
        _directoryTree = new DirectoryTree();
    }

    public class DirectoryTree
    {
        public Node _root = new Node() { Name = "root", Size = 0, Next = new List<Node>() };

        public void PrintTree(Node currentNode)
        {
            foreach(var child in currentNode.Next)
            {
                Console.WriteLine($"{child.Name}");
            }
            //Console.WriteLine($"- {currentNode.Name} ({currentNode.Type})");
            //if (currentNode.Next != null && currentNode.Next.Any())
            //{
            //    foreach(var childNode in currentNode.Next)
            //    {
            //        Console.Write("\t");
            //        PrintTree(childNode);
            //    }
            //}
        }
    }

    public class Node
    {
        public string? Name;
        public string? Type;
        public Int32 Size;
        public Node? Previous = null;
        public List<Node>? Next;

        public Node()
        {
        }

        public Node(string? name, string? type, Int32 size, Node? previous)
        {
            Name = name;
            Type = type;
            Size = size;
            Previous = previous;
            if(Type == "file")
            {
                Next = null;
            }
            else
            {
                Next = new List<Node> { };
            }
        }
    }

    public void SolvePartOne()
    {
        _currNode = _directoryTree._root;
        foreach (var commandLine in _text) {
            var commandLineSplit = commandLine.Split(' ');
            if (commandLineSplit[0].Equals("$"))
            {
                HandleCommand(commandLineSplit);
            }
            else
            {
                HandleOutput(commandLineSplit);
            }
        }
        _directoryTree.PrintTree(_directoryTree._root);
    }

    private void HandleOutput(string[] commandLineSplit)
    {
        Node newNode = null;
        if (commandLineSplit[0].Equals("dir")){
            newNode = new Node(commandLineSplit[1], commandLineSplit[0], 0, _currNode);
        }
        else
        {
            newNode = new Node(commandLineSplit[1], "file", Int32.Parse(commandLineSplit[0]), _currNode);
        }
        Console.WriteLine($"added {newNode.Name}, child of {_currNode.Name}");
        _currNode.Next.Add(newNode);
        _currNode.Size += newNode.Size;
    }

    private void HandleCommand(string[] commandLineSplit)
    {
        if (commandLineSplit[1].Equals("cd")) {
            HandleCD(commandLineSplit);        
        }
    }

    private void HandleLS(string[] commandLineSplit)
    {
    }

    private void HandleCD(string[] commandLineSplit)
    {
        var commandArg = commandLineSplit[2];
        switch (commandArg)
        {
            case "/":
                Console.WriteLine("going to root");
                _currNode = _directoryTree._root;
                break;
            case "..":
                Console.WriteLine("going up a level");
                _currNode = _currNode.Previous;
                break;
            default:
                var targetChildNode = _currNode.Next.FirstOrDefault(childNode => childNode.Name.Equals(commandArg));
                Console.WriteLine($"going to {targetChildNode.Name}, child of {_currNode.Name}");
                _currNode = targetChildNode;
                break;
        }

    }

    public void SolvePartTwo()
    {
    }
}


