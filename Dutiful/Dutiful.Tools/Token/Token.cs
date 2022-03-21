using Tools.Crypto;

namespace Dutiful.Tools.Token;

public static class TokenExtensions
{
    public static string CreateToken(this string name)
    {
        string guid = Guid.NewGuid().ToString();
        string hash = guid.CreateSHA256();
        return $"{name}-{hash}";
    }
}