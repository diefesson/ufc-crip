namespace Diefesson.Cryptool.Command;

using CommandLine;

[Verb("identify-language", HelpText ="Identifies input text language")]
public class IdentifyLanguageOptions
{ }

[Verb("caesar-encrypt", HelpText = "Encrypts input using caesar cipher")]
public class CaesarEncryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Encryption key")]
    public int key { get; set; }
}

[Verb("caesar-decrypt", HelpText = "Decrypts input using caesar cipher")]
public class CaesarDecryptOptions
{
    [Option('k', "key", Required = true, HelpText = "Decryption key")]
    public int key { get; set; }
}

[Verb("caesar-brute-force", HelpText = "Tries to decrypt and prints using ALL posible keys")]
public class CaesarBruteForceOptions
{ }

[Verb("caesar-auto", HelpText = "Decrypt using ALL keys and infers the correct one using text analisys")]
public class CaesarAutoOptions
{ }
