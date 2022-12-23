namespace AoCProblemSolvers._2017Day18;

public struct MethodCall
{
    public string Command = "";
    public string ParameterOne = "";
    public string ParameterTwo = "";

    public MethodCall(string[] methodCall)
    {
        Command = methodCall[0];
        ParameterOne = methodCall[1];
        if (methodCall.Length == 3)
        {
            ParameterTwo = methodCall[2];
        }
    }
}