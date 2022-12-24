using System.Formats.Asn1;
using AoCProblemSolvers._2015Day21;
using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers._2017Day18;

public class Day18Solver
{
    private FileReader _fileReader;
    private IEnumerable<string> _rawText;
    //TODO: Could we use hashset?
    private Dictionary<char, int> MemoryRegister = new();
    private string[] _text;
    private List<MethodCall> commands = new();
    private int frequencyPlayed = 0;

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
        for (int index = 0; index < commands.Count; index++)
        {
            var methodCall = commands[index];
            switch (methodCall.Command)
            {
                case "snd":
                    snd(methodCall.ParameterOne);
                    break;
                case "set":
                    set(methodCall.ParameterOne, methodCall.ParameterTwo);
                    break;
                case "add":
                    add(methodCall.ParameterOne, methodCall.ParameterTwo);
                    break;
                case "mul":
                    mul(methodCall.ParameterOne, methodCall.ParameterTwo);
                    break;
                case "mod":
                    mod(methodCall.ParameterOne, methodCall.ParameterTwo);
                    break;
                case "rcv":
                    rcv(methodCall.ParameterOne);
                    break;
                //TODO: handle jump logic
                case "jgz":
                    jgz(methodCall.ParameterOne, methodCall.ParameterTwo);
                    break;
            }
        }
    }

    public void snd(string parameterOne)
    {
        Int32.TryParse(parameterOne, out frequencyPlayed);
        Console.WriteLine($"Sound of frequency {parameterOne} played");
    }
    public void set(string parameterOne, string parameterTwo)
    {
        int parameterTwoValue = 0;
        
        //If Y is a number
        if (Int32.TryParse(parameterTwo, out parameterTwoValue))
        {
            if (MemoryRegister.ContainsKey(parameterOne[0]))
            {
                MemoryRegister[parameterOne[0]] = parameterTwoValue;
            }
            else
            {
                MemoryRegister.Add(parameterOne[0], parameterTwoValue);
            }
        }
        //If Y is a register
        else
        {
            if (MemoryRegister.ContainsKey(parameterOne[0]))
            {
                MemoryRegister[parameterOne[0]] = MemoryRegister[parameterTwo[0]];
            }
            else
            {
                MemoryRegister.Add(parameterOne[0], MemoryRegister[parameterTwo[0]]);
            }
        }
        
    }
    public void add(string parameterOne, string parameterTwo)
    {
        int parameterTwoValue = 0;
        
        //If Y is a number
        if (Int32.TryParse(parameterTwo, out parameterTwoValue))
        {
            if (MemoryRegister.ContainsKey(parameterOne[0]))
            {
                MemoryRegister[parameterOne[0]] += parameterTwoValue;
            }
            else
            {
                MemoryRegister.Add(parameterOne[0], parameterTwoValue);
            }
        }
        //If Y is a register
        else
        {
            if (MemoryRegister.ContainsKey(parameterOne[0]))
            {
                MemoryRegister[parameterOne[0]] += MemoryRegister[parameterTwo[0]];
            }
            else
            {
                MemoryRegister.Add(parameterOne[0], MemoryRegister[parameterTwo[0]]);
            }
        }
    }
    public void mul(string parameterOne, string parameterTwo)
    {
        int parameterTwoValue = 0;
        
        //If Y is a number
        if (Int32.TryParse(parameterTwo, out parameterTwoValue))
        {
            if (MemoryRegister.ContainsKey(parameterOne[0]))
            {
                MemoryRegister[parameterOne[0]] *= parameterTwoValue;
            }
            else
            {
                MemoryRegister.Add(parameterOne[0], 0);
            }
        }
        //If Y is a register
        else
        {
            if (MemoryRegister.ContainsKey(parameterOne[0]))
            {
                MemoryRegister[parameterOne[0]] *= MemoryRegister[parameterTwo[0]];
            }
            else
            {
                MemoryRegister.Add(parameterOne[0], 0);
            }
        }
    }
    public void mod(string parameterOne, string parameterTwo)
    {
        int parameterTwoValue = 0;
        
        //If Y is a number
        if (Int32.TryParse(parameterTwo, out parameterTwoValue))
        {
            if (MemoryRegister.ContainsKey(parameterOne[0]))
            {
                MemoryRegister[parameterOne[0]] %= parameterTwoValue;
            }
            else
            {
                MemoryRegister.Add(parameterOne[0], 0);
            }
        }
        //If Y is a register
        else
        {
            if (MemoryRegister.ContainsKey(parameterOne[0]))
            {
                MemoryRegister[parameterOne[0]] %= MemoryRegister[parameterTwo[0]];
            }
            else
            {
                MemoryRegister.Add(parameterOne[0], 0);
            }
        }
    }
    public void rcv(string parameterOne)
    {
        int parameterOneValue = 0;
        
        //If Y is a number
        if (Int32.TryParse(parameterOne, out parameterOneValue))
        {
            Console.WriteLine("Last played frequency: " + frequencyPlayed);
        }
        //If Y is a register
        else if (MemoryRegister[parameterOne[0]] != 0)
        {
            Console.WriteLine("Last played frequency: " + frequencyPlayed);
        }
    }
    public void jgz(string parameterOne, string parameterTwo)
    {
        
    }
    
}