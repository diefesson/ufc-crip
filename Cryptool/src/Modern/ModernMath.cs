namespace Diefesson.Cryptool.Modern;

public static class ModernMath
{
    public static (int, int, int) ExtendedEuclideanAlgorithm(int a, int b)
    {
        var (pr, r) = a >= b ? (a, b) : (b, a);
        var (px, x) = a >= b ? (1, 0) : (0, 1);
        var (py, y) = a >= b ? (0, 1) : (1, 0);
        while (r != 0)
        {
            var q = pr / r;
            (pr, r) = (r, pr - q * r);
            (px, x) = (x, px - q * x);
            (py, y) = (y, py - q * y);
        }
        return (pr, px, py);
    }
}