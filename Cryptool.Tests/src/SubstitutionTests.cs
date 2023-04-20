using Diefesson.Cryptool.Classic;

namespace Diefesson.Cryptool.Tests;

public class SubstitutionTests
{
    private static string Plaintext = "Hello World!";

    private static string Ciphertext = "Itssg Vgksr!";

    private static string Key = "QWERTYUIOPASDFGHJKLZXCVBNM";

    [Fact]
    public void EncryptTest()
    {
        var result = Substitution.Encrypt(Plaintext, Key);
        Assert.Equal(Ciphertext, result);
    }

    [Fact]
    public void DecryptTest()
    {
        var result = Substitution.Decrypt(Ciphertext, Key);
        Assert.Equal(Plaintext, result);
    }
}