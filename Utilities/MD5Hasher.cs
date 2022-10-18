using System.Security.Cryptography;

namespace AoCProblemSolvers.Utilities;

public class Md5Hasher
{
    private string inputString;

    public Md5Hasher(string stringToHash)
    {
        var hasher = new HashCode();
    }
}