namespace Diefesson.Cryptool.Cli;

using CommandLine;

[Verb("sanitize", HelpText = "Sanitizes input to contain only uppercase letters")]
public class SanitizeOptions
{
    [Option('c', "convert", Required = false, Default = true, HelpText = "Convert diacritics?")]
    public bool? convert { get; set; } // '?' is necessary so the parser uses argument value

    [Option('s', "spaces", Required = false, Default = true, HelpText = "Keep whitespaces?")]
    public bool? spaces { get; set; }

    [Option('l', "lines", Required = false, Default = true, HelpText = "Keep lines?")]
    public bool? lines { get; set; }

    [Option('p', "punctuation", Required = false, Default = true, HelpText = "Keep punctuation?")]
    public bool? punctuation { get; set; }

    [Option('u', "upper", Required = false, Default = true, HelpText = "Convert to uppercase?")]
    public bool? upper { get; set; }
}

[Verb("identify-language", HelpText = "Identifies input text language")]
public class IdentifyLanguageOptions
{ }

[Verb("caesar-encrypt", HelpText = "Encrypts input using Caesar Cipher")]
public class CaesarEncryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Encryption key")]
    public int key { get; set; }
}

[Verb("caesar-decrypt", HelpText = "Decrypts input using Caesar Cipher")]
public class CaesarDecryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Decryption key")]
    public int key { get; set; }
}

[Verb("caesar-brute-force", HelpText = "Tries to decrypt and prints using ALL posible keys")]
public class CaesarBruteForceOptions
{ }

[Verb("caesar-find-key", HelpText = "Decrypt using ALL keys and infers the correct one using text analisys")]
public class CaesarAutoOptions
{ }

[Verb("vigenere-encrypt", HelpText = "Encrypts input using Vigenere Cipher")]
public class VigenereEncryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Encryption key")]
    public string? key { get; set; }
}

[Verb("vigenere-decrypt", HelpText = "Decrypts input using Vigenere Cipher")]
public class VigenereDecryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Decryption key")]
    public string? key { get; set; }
}

[Verb("autokey-encrypt", HelpText = "Encrypts input using AutoKey Cipher")]
public class AutoKeyEncryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Encryption key")]
    public string? key { get; set; }
}

[Verb("autokey-decrypt", HelpText = "Decrypts input using AutoKey Cipher")]
public class AutoKeyDecryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Decryption key")]
    public string? key { get; set; }
}
