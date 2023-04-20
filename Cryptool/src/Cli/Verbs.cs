namespace Diefesson.Cryptool.Cli;

using CommandLine;

[Verb("sanitize", HelpText = "Sanitizes input to contain only uppercase letters")]
public class SanitizeOptions
{
    [Option('c', "convert", Default = true, HelpText = "Convert diacritics?")]
    public bool? Convert { get; set; } // '?' is necessary so the parser uses argument value

    [Option('s', "spaces", Default = true, HelpText = "Keep whitespaces?")]
    public bool? Spaces { get; set; }

    [Option('l', "lines", Default = true, HelpText = "Keep lines?")]
    public bool? Lines { get; set; }

    [Option('p', "punctuation", Default = true, HelpText = "Keep punctuation?")]
    public bool? Punctuation { get; set; }

    [Option('u', "upper", Default = true, HelpText = "Convert to uppercase?")]
    public bool? Upper { get; set; }
}

[Verb("analysis-freq", HelpText = "Performs n-gram frequency analysis")]
public class AnalysisFreqOptions
{
    [Option('s', "size", Default = 1, HelpText = "N-gram size")]
    public int Size { get; set; }

    [Option('c', "count", Default = 10, HelpText = "The number of entries to show")]
    public int Count { get; set; }
}

[Verb("analysis-language", HelpText = "Identifies input text language")]
public class AnalysisLanguageOptions
{ }

[Verb("caesar-encrypt", HelpText = "Encrypts input using Caesar Cipher")]
public class CaesarEncryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Encryption key")]
    public int Key { get; set; }
}

[Verb("caesar-decrypt", HelpText = "Decrypts input using Caesar Cipher")]
public class CaesarDecryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Decryption key")]
    public int Key { get; set; }
}

[Verb("caesar-brute-force", HelpText = "Tries to decrypt and prints using ALL possible keys")]
public class CaesarBruteForceOptions
{ }

[Verb("caesar-find-key", HelpText = "Decrypt using ALL keys and infers the correct one using text analysis")]
public class CaesarAutoOptions
{ }

[Verb("substitution-encrypt", HelpText = "Encrypts using a simple substitution cipher")]
public class SubstitutionEncryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Encryption key")]
    public string? Key { get; set; }
}

[Verb("substitution-decrypt", HelpText = "Decrypts using a simple substitution cipher")]
public class SubstitutionDecryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Encryption key")]
    public string? Key { get; set; }
}

[Verb("vigenere-encrypt", HelpText = "Encrypts input using Vigenere Cipher")]
public class VigenereEncryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Encryption key")]
    public string? Key { get; set; }
}

[Verb("vigenere-decrypt", HelpText = "Decrypts input using Vigenere Cipher")]
public class VigenereDecryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Decryption key")]
    public string? Key { get; set; }
}

[Verb("autokey-encrypt", HelpText = "Encrypts input using AutoKey Cipher")]
public class AutoKeyEncryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Encryption key")]
    public string? Key { get; set; }
}

[Verb("autokey-decrypt", HelpText = "Decrypts input using AutoKey Cipher")]
public class AutoKeyDecryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Decryption key")]
    public string? Key { get; set; }
}
