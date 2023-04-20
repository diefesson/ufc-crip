namespace Diefesson.Cryptool.Tests;

using Diefesson.Cryptool.Classic;

public class VigenereTest
{
    private static string Plaintext = "Hello World!";

    private static string Ciphertext = "Hfnlp Yosnd!";

    private static string Key = "abc";


    [Fact]
    public void EncryptTest()
    {
        var result = Vigenere.Encrypt(Plaintext, Key);
        Assert.Equal(Ciphertext, result);
    }

    [Fact]
    public void DecryptTest()
    {
        var result = Vigenere.Decrypt(Ciphertext, Key);
        Assert.Equal(Plaintext, result);
    }
}