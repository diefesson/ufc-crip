namespace Diefesson.Cryptool.Tests;

using Diefesson.Cryptool.Classic;

public class CaesarTest
{
    private static string plaintext = "Hello World!";

    private static string ciphertext = "Olssv Dvysk!";

    private static int key = 7;


    [Fact]
    public void EncryptTest()
    {
        var result = Caesar.Encrypt(plaintext, key);
        Assert.Equal(ciphertext, result);
    }

    [Fact]
    public void DecryptTest()
    {
        var result = Caesar.Decrypt(ciphertext, key);
        Assert.Equal(plaintext, result);
    }
}