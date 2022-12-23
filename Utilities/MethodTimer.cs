using System.Diagnostics;

namespace AoCProblemSolvers.Utilities;

public static class MethodTimer
{
    public static void Time(Action action, string description, int repeat = 1)
    {
        // warm-up to ensure methods have been JIT compiled
        action();
        
        var sw = new Stopwatch();
        try
        {
            sw.Start();
            for (var i = 0; i < repeat; i++)
            {
                action();
            }
        }
        finally
        {
            Console.WriteLine($"{description}: {sw.Elapsed.TotalMilliseconds}ms");
        }
    }
}