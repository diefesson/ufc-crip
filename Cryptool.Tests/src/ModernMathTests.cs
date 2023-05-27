namespace Diefesson.Cryptool.Tests;

using Diefesson.Cryptool.Modern;

public class ModernMathTests
{
    [Fact]
    public void ExtendedEuclideanAlgorithmTest()
    {
        Assert.Equal((1, 1, -1), ModernMath.ExtendedEuclideanAlgorithm(3, 2));
        Assert.Equal((2, 0, 1), ModernMath.ExtendedEuclideanAlgorithm(4, 2));
        Assert.Equal((1, -2, 3), ModernMath.ExtendedEuclideanAlgorithm(7, 5));
        Assert.Equal((1, 6, -11), ModernMath.ExtendedEuclideanAlgorithm(24, 13));
    }
}