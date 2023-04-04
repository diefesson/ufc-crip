using Diefesson.Cryptool.Analisys;

var text = "";

var languageIdentifier = new LanguageIdentifier(
    DefaultTrigramsLists.ENUSTrigrams,
    DefaultTrigramsLists.PTBRTrigrams
);

var scores = languageIdentifier.analyze(text);
var language = languageIdentifier.language(text);

Console.WriteLine($"detected language: {language}");
foreach (var (l, s) in scores)
{
    Console.WriteLine($"language: {l} score: {s} ");
}
