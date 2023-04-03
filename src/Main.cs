using Diefesson.Cryptool.Classic;

var key = 3;
var plain = "My Super Secret Message";

var encrypter = new CaesarEncrypter(key);
var decrypter = new CaesarDecrypter(key);

var crypted = String.Concat(plain.Select(encrypter.Crypt));
var decrypted = String.Concat(crypted.Select(decrypter.Decrypt));

Console.WriteLine($"plain: {plain}");
Console.WriteLine($"crypted: {crypted}");
Console.WriteLine($"decrypted: {decrypted}");