namespace Diefesson.Cryptool.Command;

using CommandLine;

[Verb("identify-language")]
public class IdentifyLanguageOptions
{ }

[Verb("caesar-encrypt")]
public class CaesarEncryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Encryption key")]
    public int key { get; set; }
}

[Verb("caesar-decrypt")]
public class CaesarDecryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Decryption key")]
    public int key { get; set; }
}

[Verb("caesar-brute-force")]
public class CaesarBruteForceOptions
{ }

[Verb("caesar-auto")]
public class CaesarAutoOptions
{ }