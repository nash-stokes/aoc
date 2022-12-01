using System.Collections.Generic;
using System.IO;

namespace AoCProblemSolvers.Utilities;

public class FileReader
{
    public IEnumerable<string> Read(string fileName)
    {
        string line;
        using (var reader = new StreamReader(fileName))
        {
            while ((line = reader.ReadLine()) != null) yield return line;
        }
    }
}