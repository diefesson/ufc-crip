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
            .ParseArguments<IdentifyLanguageOptions, CaesarEncryptOptions, CaesarDecryptOptions, CaesarBruteForceOptions, CaesarAutoOptions>(args)
            .MapResult(
            (IdentifyLanguageOptions o) =>
            {
                var text = Console.In.ReadToEnd();
                var languageIdenfier = new LanguageIdentifier(TrigramList.ENUS, TrigramList.PTBR);
                var result = languageIdenfier.InferLanguage(text);
                Console.WriteLine($"Language: {result.Language} Score ${result.Score}");
                return 0;
            },
            (CaesarEncryptOptions o) =>
            {
                var plain = Console.In.ReadToEnd();
                var encrypter = new CaesarEncrypter(o.key);
                var encrypted = String.Concat(plain.Select(encrypter.Encrypt));
                Console.Write(encrypted);
                return 0;
            },
            (CaesarDecryptOptions o) =>
            {
                var encrypted = Console.In.ReadToEnd();
                var decrypter = new CaesarDecrypter(o.key);
                var plain = String.Concat(encrypted.Select(decrypter.Decrypt));
                Console.Write(plain);
                return 0;
            },
            (CaesarBruteForceOptions o) =>
            {
                var encrypted = Console.In.ReadToEnd();
                var canditates = CaesarBruteForce.bruteForce(encrypted);
                for (var i = 0; i < canditates.Length; i++)
                {
                    Console.WriteLine($"Key: {i} Candidate: {canditates[i]}");
                }
                return 0;
            },
            (CaesarAutoOptions o) =>
            {
                var encrypted = Console.In.ReadToEnd();
                var languageIdenfier = new LanguageIdentifier(TrigramList.ENUS, TrigramList.PTBR);
                var canditates = CaesarBruteForce.bruteForce(encrypted);
                var (result, key) = canditates
                    .Select(c => languageIdenfier.InferLanguage(c))
                    .Select((r, i) => (r, i))
                    .MaxBy((e => e.r.Score)!);
                Console.WriteLine($"Language: {result.Language} Score: {result.Score} Key: {key}");
                return 0;
            },
            _ => 1
        );
    }
}