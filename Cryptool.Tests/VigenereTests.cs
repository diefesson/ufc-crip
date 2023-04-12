namespace Diefesson.Cryptool.Tests;

using Diefesson.Cryptool.Classic;

public class VigenereTest
{
    private static string plaintext = "Hello World!";

    private static string ciphertext = "Hfnlp Yosnd!";

    private static string key = "abc";


    [Fact]
    public void EncryptTest()
    {
        var result = Vigenere.Encrypt(plaintext, key);
        Assert.Equal(ciphertext, result);
    }

    [Fact]
    public void DecryptTest()
    {
        var result = Vigenere.Decrypt(ciphertext, key);
        Assert.Equal(plaintext, result);
    }
}