namespace Diefesson.Cryptool.Tests;

using Diefesson.Cryptool.Classic;

public class AutokeyTest
{
    private static string plaintext = "Hello World!";

    private static string ciphertext = "Hfnss Hzfhr!";

    private static string key = "abc";


    [Fact]
    public void EncryptTest()
    {
        var result = AutoKey.Encrypt(plaintext, key);
        Assert.Equal(ciphertext, result);
    }

    [Fact]
    public void DecryptTest()
    {
        var result = AutoKey.Decrypt(ciphertext, key);
        Assert.Equal(plaintext, result);
    }
}