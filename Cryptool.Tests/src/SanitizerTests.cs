namespace Diefesson.Cryptool.Tests;

using Diefesson.Cryptool.Analysis;

public class SanitizerTests
{
    [Fact]
    public void Test()
    {
        var text = "O mundo é estranho.\n";
        Assert.Equal("O MUNDO E ESTRANHO.\n", Sanitizer.Sanitize(text, new SanitizerOptions { }));
        Assert.Equal("O MUNDO  ESTRANHO.\n", Sanitizer.Sanitize(text, new SanitizerOptions { Convert = false }));
        Assert.Equal("OMUNDOEESTRANHO.\n", Sanitizer.Sanitize(text, new SanitizerOptions { Spaces = false }));
        Assert.Equal("O MUNDO E ESTRANHO.", Sanitizer.Sanitize(text, new SanitizerOptions { Lines = false }));
        Assert.Equal("O MUNDO E ESTRANHO\n", Sanitizer.Sanitize(text, new SanitizerOptions { Punctuation = false }));
        Assert.Equal("O mundo e estranho.\n", Sanitizer.Sanitize(text, new SanitizerOptions { Upper = false }));
    }
}