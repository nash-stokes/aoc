using AoCProblemSolvers.Utilities;

namespace AoCProblemSolvers._2022Day5;

public class Day5Solver
{
    private FileReader _fileReader;
    private IEnumerable<string> _rawText;
    private string[] _text;
    
    public Day5Solver()
    {
        _fileReader = new FileReader();
        _rawText = _fileReader.Read("../../../AoCDay5/input.txt");
        _text = _rawText.ToArray();
    }
    
    public void SolvePartOne()
    {
        Stack<char> stack1 = new Stack<char>();
        stack1.Push('m');
        stack1.Push('j');
        stack1.Push('c');
        stack1.Push('b');
        stack1.Push('f');
        stack1.Push('r');
        stack1.Push('l');
        stack1.Push('h');
        Stack<char> stack2 = new Stack<char>();
        stack2.Push('m');
        stack2.Push('j');
        stack2.Push('c');
        stack2.Push('b');
        stack2.Push('f');
        stack2.Push('r');
        stack2.Push('l');
        stack2.Push('h');
        Stack<char> stack3 = new Stack<char>();
        stack3.Push('m');
        stack3.Push('j');
        stack3.Push('c');
        stack3.Push('b');
        stack3.Push('f');
        stack3.Push('r');
        stack3.Push('l');
        stack3.Push('h');
        Stack<char> stack4 = new Stack<char>();
        stack4.Push('m');
        stack4.Push('j');
        stack4.Push('c');
        stack4.Push('b');
        stack4.Push('f');
        stack4.Push('r');
        stack4.Push('l');
        stack4.Push('h');
        Stack<char> stack5 = new Stack<char>();
        stack5.Push('m');
        stack5.Push('j');
        stack5.Push('c');
        stack5.Push('b');
        stack5.Push('f');
        stack5.Push('r');
        stack5.Push('l');
        stack5.Push('h');
        Stack<char> stack6 = new Stack<char>();
        stack6.Push('m');
        stack6.Push('j');
        stack6.Push('c');
        stack6.Push('b');
        stack6.Push('f');
        stack6.Push('r');
        stack6.Push('l');
        stack6.Push('h');
        Stack<char> stack7 = new Stack<char>();
        stack7.Push('m');
        stack7.Push('j');
        stack7.Push('c');
        stack7.Push('b');
        stack7.Push('f');
        stack7.Push('r');
        stack7.Push('l');
        stack7.Push('h');
        Stack<char> stack8 = new Stack<char>();
        stack8.Push('m');
        stack8.Push('j');
        stack8.Push('c');
        stack8.Push('b');
        stack8.Push('f');
        stack8.Push('r');
        stack8.Push('l');
        stack8.Push('h');
        Stack<char> stack9 = new Stack<char>();
        stack9.Push('m');
        stack9.Push('j');
        stack9.Push('c');
        stack9.Push('b');
        stack9.Push('f');
        stack9.Push('r');
        stack9.Push('l');
        stack9.Push('h');
    }

    public void SolvePartTwo()
    {
       
    }
}