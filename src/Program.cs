var alphabet = Enumerable.Range('a', 'z').Select(c => (char) c).ToArray();

var text = "segredo".ToCharArray();

var cipher = new SimpleRot(alphabet, 3);
var crypted = text.Select(c => cipher.Crypt(c)).ToArray();
var decrypted = crypted.Select(c => cipher.Decrypt(c)).ToArray();

Console.WriteLine($"Text: {new String(text)}");
Console.WriteLine($"Crypted: {new String(crypted)}");
Console.WriteLine($"Decrypted: {new String(decrypted)}");