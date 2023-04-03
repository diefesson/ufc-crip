using Diefesson.Cryptool.Classic;

var key = 3;
var plain = "My Super Secret Message";

var encrypter = new CaesarEncrypter(key);

var encrypted = String.Concat(plain.Select(encrypter.Crypt));

var candidates = CaesarBruteForce.bruteForce(encrypted);
for(var i = 0; i < encrypted.Length; i++)
{
    Console.WriteLine($"{i} : {candidates[i]}");
}
