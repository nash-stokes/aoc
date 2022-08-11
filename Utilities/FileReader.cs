namespace AoCDay1.Utilities;

public class FileReader
{
    public IEnumerable<string> read(string fileName)
    {
        string line;
        using (var reader = new StreamReader(fileName))
        {
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}