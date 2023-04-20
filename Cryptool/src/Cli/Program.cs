namespace Diefesson.Cryptool.Cli;

using System.Text;

using CommandLine;

using Diefesson.Cryptool.Analysis;
using Diefesson.Cryptool.Classic;


public static class Program
{

    private const bool Test = false;

    public static void QuickTest()
    { }

    public static void Main(string[] args)
    {
        if (Test)
        {
#pragma warning disable CS0162
            QuickTest();
            return;
        }

        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
#pragma warning disable CS0162
        Parser
            .Default
            .ParseArguments<SanitizeOptions, AnalysisFreqOptions, AnalysisLanguageOptions, CaesarEncryptOptions, CaesarDecryptOptions, CaesarBruteForceOptions, CaesarAutoOptions, SubstitutionEncryptOptions, SubstitutionDecryptOptions, VigenereEncryptOptions, VigenereDecryptOptions, AutoKeyEncryptOptions, AutoKeyDecryptOptions>(args)
            .MapResult(
            (SanitizeOptions options) =>
            {
                Sanitize(options);
                return 0;
            },
            (AnalysisFreqOptions options) =>
            {
                AnalysisFreq(options);
                return 0;
            },
            (AnalysisLanguageOptions options) =>
            {
                AnalysisLanguage(options);
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
            (CaesarAutoOptions _) =>
            {
                CaesarAuto();
                return 0;
            },
            (SubstitutionEncryptOptions options) =>
            {
                SubstitutionEncrypt(options);
                return 0;
            },
            (SubstitutionDecryptOptions options) =>
            {
                SubstitutionDecrypt(options);
                return 0;
            },
            (VigenereEncryptOptions options) =>
            {
                VigenereEncrypt(options);
                return 0;
            },
            (VigenereDecryptOptions options) =>
            {
                VigenereDecrypt(options);
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

    private static void Sanitize(SanitizeOptions options)
    {
        var text = Console.In.ReadToEnd();
        var clean = Sanitizer.Sanitize(text, new SanitizerOptions
        {
            // TODO: find out why null forgiving is not sufficient for bool
            Convert = options.Convert!.Value,
            Spaces = options.Spaces!.Value,
            Lines = options.Lines!.Value,
            Punctuation = options.Punctuation!.Value,
            Upper = options.Upper!.Value,
        });
        Console.Write(clean);
    }

    private static void AnalysisFreq(AnalysisFreqOptions options)
    {
        if (options.Size <= 0)
        {
            Console.WriteLine("size must be positive");
            return;
        }
        if (options.Count <= 0)
        {
            Console.WriteLine("count must be positive");
        }
        var text = Console.In.ReadToEnd();
        var frequencies = new FreqDist<String>();
        foreach (var ngram in text.NGrams(options.Size))
        {
            frequencies.Count(ngram, 1);
        }
        foreach (var entry in frequencies.Tops().Take(options.Count))
        {
            var key = entry.Key
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");
            Console.WriteLine($"{key} : {entry.Count} ({entry.Freq:00.0}%)");
        }
    }

    private static void AnalysisLanguage(AnalysisLanguageOptions options)
    {
        var text = Console.In.ReadToEnd();
        var languageIdenfier = new LanguageIdentifier(TrigramList.ENUS, TrigramList.PTBR);
        var result = languageIdenfier.InferLanguage(text);
        Console.WriteLine($"Language: {result.Language} Score {result.Score}");
    }

    private static void CaesarEncrypt(CaesarEncryptOptions options)
    {
        var plaintext = Console.In.ReadToEnd();
        var ciphertext = Caesar.Encrypt(plaintext, options.Key);
        Console.Write(ciphertext);
    }

    private static void CaesarDecrypt(CaesarDecryptOptions options)
    {
        var ciphertext = Console.In.ReadToEnd();
        var plaintext = Caesar.Decrypt(ciphertext, options.Key);
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
            .Select((AnalysisEntry r, int i) => (r, i))
            .MaxBy(e => e.r.Score!);
        Console.WriteLine($"Language: {result.Language} Score: {result.Score} Key: {key}");
    }

    private static void SubstitutionEncrypt(SubstitutionEncryptOptions options)
    {
        var plaintext = Console.In.ReadToEnd();
        var ciphertext = Substitution.Encrypt(plaintext, Substitution.ParseKey(options.Key!));
        Console.Write(ciphertext);
    }

    private static void SubstitutionDecrypt(SubstitutionDecryptOptions options)
    {
        var ciphertext = Console.In.ReadToEnd();
        var plaintext = Substitution.Decrypt(ciphertext, Substitution.ParseKey(options.Key!));
        Console.Write(plaintext);
    }

    private static void VigenereEncrypt(VigenereEncryptOptions options)
    {
        var plaintext = Console.In.ReadToEnd();
        var ciphertext = Vigenere.Encrypt(plaintext, options.Key!);
        Console.Write(ciphertext);
    }

    private static void VigenereDecrypt(VigenereDecryptOptions options)
    {
        var ciphertext = Console.In.ReadToEnd();
        var plaintext = Vigenere.Decrypt(ciphertext, options.Key!);
        Console.Write(plaintext);
    }

    private static void AutoKeyEncrypt(AutoKeyEncryptOptions options)
    {
        var plaintext = Console.In.ReadToEnd();
        var ciphertext = AutoKey.Encrypt(plaintext, options.Key!);
        Console.Write(ciphertext);
    }

    private static void AutoKeyDecrypt(AutoKeyDecryptOptions options)
    {
        var ciphertext = Console.In.ReadToEnd();
        var plaintext = AutoKey.Decrypt(ciphertext, options.Key!);
        Console.Write(plaintext);
    }
}