namespace Diefesson.Cryptool.Tests;

using Diefesson.Cryptool.Classic;

public class CaesarTest
{
    private static string Plaintext = "Hello World!";

    private static string Ciphertext = "Olssv Dvysk!";

    private static int Key = 7;


    [Fact]
    public void EncryptTest()
    {
        var result = Caesar.Encrypt(Plaintext, Key);
        Assert.Equal(Ciphertext, result);
    }

    [Fact]
    public void DecryptTest()
    {
        var result = Caesar.Decrypt(Ciphertext, Key);
        Assert.Equal(Plaintext, result);
    }
}