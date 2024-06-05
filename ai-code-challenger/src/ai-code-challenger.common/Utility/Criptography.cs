using System.CodeDom.Compiler;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace ai_code_challenger.common;

public static class Criptography
{
    public static string Encrypt(string password)
    {
        string passwordWithInternPassword = $"{password}{saltGenerator()}";

        byte[] bytes = Encoding.UTF8.GetBytes(passwordWithInternPassword);

        var sha512 = SHA512.Create();

        byte[] hashBytes = sha512.ComputeHash(bytes);

        return StringBytes(hashBytes);
    }

    public static string PasswordEncrypt(string password)
    {
        string passwordWithInternPassword = $"{password}";

        byte[] bytes = Encoding.UTF8.GetBytes(passwordWithInternPassword);

        var sha512 = SHA512.Create();

        byte[] hashBytes = sha512.ComputeHash(bytes);

        return StringBytes(hashBytes);
    }
    private static string StringBytes(byte[] hashBytes)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (byte b in hashBytes)
        {
            string hex = b.ToString("x2");
            stringBuilder.Append(hex);
        }

        return stringBuilder.ToString();
    }
    private static string saltGenerator()
    {
        byte[] buff = new byte[20];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(buff);

        return Convert.ToBase64String(buff);
    }
}
