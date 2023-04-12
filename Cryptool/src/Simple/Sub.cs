namespace Diefesson.Cryptool.Simple;

public class Sub
{
    private char[] alphabetA, alphabetB;

    public Sub(char[] alphabetA, char[] alphabetB)
    {
        if (alphabetA.Length != alphabetB.Length)
        {
            throw new ArgumentException("alphabet must have same lenght");
        }
        this.alphabetA = alphabetA;
        this.alphabetB = alphabetB;
    }

    public char Crypt(char c)
    {
        int index = Array.IndexOf(alphabetA, c);
        if (index == -1)
        {
            throw new ArgumentException();
        }
        return alphabetB[index];
    }

    public char Decrypt(char c)
    {
        int index = Array.IndexOf(alphabetB, c);
        if (index == -1)
        {
            throw new ArgumentException();
        }
        return alphabetA[index];
    }
}