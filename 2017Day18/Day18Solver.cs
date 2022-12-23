using System.Formats.Asn1;
using AoCProblemSolvers._2015Day21;
using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers._2017Day18;

public class Day18Solver
{
    private FileReader _fileReader;
    private IEnumerable<string> _rawText;
    private HashSet<Register> MemoryRegister = new();
    private string[] _text;
    private List<MethodCall> commands = new();

    public Day18Solver()
    {
        _fileReader = new FileReader();
        _rawText = _fileReader.Read("../../../2017Day18/input.txt");
        _text = _rawText.ToArray();
        foreach (var rawMethodCall in _text)
        {
            var methodCall = rawMethodCall.Split(' ');
            commands.Add(new MethodCall(methodCall));
        }
        commands.ForEach(x => Console.WriteLine(x.Command + x.ParameterOne + x.ParameterTwo));
    }

    public void SolvePartOne()
    {
        ProcessCommands();
    }

    public void ProcessCommands()
    {
        foreach (var methodCall in commands)
        {
            if(methodCall.Command == "snd")
            {
                snd(methodCall.ParameterOne);
            }
            else if(methodCall.Command == "set")
            {
                set(methodCall.ParameterOne, methodCall.ParameterTwo);
            }
            else if(methodCall.Command == "add")
            {
                add(methodCall.ParameterOne, methodCall.ParameterTwo);
            }
            else if(methodCall.Command == "mul")
            {
                mul(methodCall.ParameterOne, methodCall.ParameterTwo);
            }
            else if(methodCall.Command == "mod")
            {
                mod(methodCall.ParameterOne, methodCall.ParameterTwo);
            }
            else if(methodCall.Command == "rcv")
            {
                rcv(methodCall.ParameterOne);
            }
            else if(methodCall.Command == "jgz")
            {
                jgz(methodCall.ParameterOne, methodCall.ParameterTwo);
            }
        }
    }

    public void snd(string parameterOne)
    {
        Console.WriteLine($"Sound of frequency {parameterOne} played");
    }
    public void set(string parameterOne, string parameterTwo)
    {
        MemoryRegister.Add(new Register(parameterOne[0], Int32.Parse(parameterTwo)));
    }
    public void add(string parameterOne, string parameterTwo)
    {
    }
    public void mul(string parameterOne, string parameterTwo)
    {
        
    }
    public void mod(string parameterOne, string parameterTwo)
    {
        
    }
    public void rcv(string parameterOne)
    {
        
    }
    public void jgz(string parameterOne, string parameterTwo)
    {
        
    }
    
}