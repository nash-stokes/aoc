using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace AoCProblemSolvers.Utilities;

public static class Md5Hasher
{

    public static string hashIt(string stringToHash)
    {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(stringToHash);
        byte[] outputBytes = MD5.Create().ComputeHash(inputBytes);
        string hexString = Convert.ToHexString(outputBytes);
        return hexString;
    }


}