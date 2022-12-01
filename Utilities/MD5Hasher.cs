using System;
using System.Security.Cryptography;
using System.Text;

namespace AoCProblemSolvers.Utilities;

public static class Md5Hasher
{
    public static string hashIt(string stringToHash)
    {
        var inputBytes = Encoding.ASCII.GetBytes(stringToHash);
        var outputBytes = MD5.Create().ComputeHash(inputBytes);
        var hexString = Convert.ToHexString(outputBytes);
        return hexString;
    }
}