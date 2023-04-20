namespace Diefesson.Cryptool.Tests;

using Diefesson.Cryptool.Classic;

public class AutokeyTest
{
    private static string Plaintext = "Hello World!";

    private static string Ciphertext = "Hfnss Hzfhr!";

    private static string Key = "abc";


    [Fact]
    public void EncryptTest()
    {
        var result = AutoKey.Encrypt(Plaintext, Key);
        Assert.Equal(Ciphertext, result);
    }

    [Fact]
    public void DecryptTest()
    {
        var result = AutoKey.Decrypt(Ciphertext, Key);
        Assert.Equal(Plaintext, result);
    }
}