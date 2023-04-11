namespace Diefesson.Cryptool;

using Diefesson.Cryptool.Analisys;
using Diefesson.Cryptool.Command;
using Diefesson.Cryptool.Classic;
using CommandLine;

public static class Program
{
    public static void Main(string[] args)
    {
        Parser
            .Default
            .ParseArguments<IdentifyLanguageOptions, CaesarEncryptOptions, CaesarDecryptOptions, CaesarBruteForceOptions, CaesarAutoOptions, AutoKeyEncryptOptions, AutoKeyDecryptOptions>(args)
            .MapResult(
            (IdentifyLanguageOptions options) =>
            {
                IdentifyLanguage(options);
                return 0;
            },
            (CaesarEncryptOptions options) =>
            {
                CaesarEncrypt(options);
                return 0;
            },
            (CaesarDecryptOptions options) =>
            {
                CaesarDecrypt(options);
                return 0;
            },
            (CaesarBruteForceOptions _) =>
            {
                CaesarBruteForce();
                return 0;
            },
            (CaesarAutoOptions o) =>
            {
                CaesarAuto();
                return 0;
            },
            (AutoKeyEncryptOptions options) =>
            {
                AutoKeyEncrypt(options);
                return 0;
            },
            (AutoKeyDecryptOptions options) =>
            {
                AutoKeyDecrypt(options);
                return 0;
            },
            _ => 1
        );
    }


    private static void IdentifyLanguage(IdentifyLanguageOptions options)
    {
        var text = Console.In.ReadToEnd();
        var languageIdenfier = new LanguageIdentifier(TrigramList.ENUS, TrigramList.PTBR);
        var result = languageIdenfier.InferLanguage(text);
        Console.WriteLine($"Language: {result.Language} Score ${result.Score}");
    }

    private static void CaesarEncrypt(CaesarEncryptOptions options)
    {
        var plaintext = Console.In.ReadToEnd();
        var ciphertext = Caesar.Encrypt(plaintext, options.key);
        Console.Write(ciphertext);
    }

    private static void CaesarDecrypt(CaesarDecryptOptions options)
    {
        var ciphertext = Console.In.ReadToEnd();
        var plaintext = Caesar.Decrypt(ciphertext, options.key);
        Console.Write(plaintext);
    }

    private static void CaesarBruteForce()
    {
        var ciphertext = Console.In.ReadToEnd();
        var candidates = Classic.CaesarBruteForce.bruteForce(ciphertext);
        for (var i = 0; i < candidates.Length; i++)
        {
            Console.WriteLine($"Key: {i}");
            Console.WriteLine(candidates[i]);
        }
    }

    private static void CaesarAuto()
    {
        var ciphertext = Console.In.ReadToEnd();
        var languageIdentifier = new LanguageIdentifier(TrigramList.ENUS, TrigramList.PTBR);
        var candidates = Classic.CaesarBruteForce.bruteForce(ciphertext);
        var (result, key) = candidates
            .Select(c => languageIdentifier.InferLanguage(c))
            .Select((AnalisysEntry r, int i) => (r, i))
            .MaxBy(e => e.r.Score!);
        Console.WriteLine($"Language: {result.Language} Score: {result.Score} Key: {key}");
    }

    private static void AutoKeyEncrypt(AutoKeyEncryptOptions options)
    {
        var plaintext = Console.In.ReadToEnd();
        var ciphertext = AutoKey.Encrypt(plaintext, options.key!);
        Console.Write(ciphertext);
    }

    private static void AutoKeyDecrypt(AutoKeyDecryptOptions options)
    {
        var ciphertext = Console.In.ReadToEnd();
        var plaintext = AutoKey.Decrypt(ciphertext, options.key!);
        Console.Write(plaintext);
    }
}