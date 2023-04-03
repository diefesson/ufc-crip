namespace Diefesson.Cryptool.Classic;

using Diefesson.Cryptool;

public class CaesarEncrypter
{
    private readonly int key;

    public CaesarEncrypter(int key)
    {
        this.key = key;
    }

    public char Crypt(char p)
    {
        if (!Char.IsAsciiLetter(p))
            return p;
        var upper = Char.IsUpper(p);
        var index = CTMath.Mod(Char.ToLower(p) - 'a' + key, Consts.AlphabetLen);
        var e = (char)(index + 'a');
        if (upper)
            e = Char.ToUpper(e);
        return e;
    }
}

public class CaesarDecrypter
{
    private readonly int key;

    public CaesarDecrypter(int key)
    {
        this.key = key;
    }

    public char Decrypt(char e)
    {
        if (!Char.IsAsciiLetter(e))
            return e;

        var upper = Char.IsUpper(e);
        var index = CTMath.Mod(Char.ToLower(e) - 'a' - key, Consts.AlphabetLen);
        var p = (char)(index + 'a');
        if (upper)
            p = Char.ToUpper(p);
        return p;
    }


}