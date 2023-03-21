public class Subs
{
    char[] alphabetA, alphabetB;

    public Subs(char[] alphabetA, char[] alphabetB)
    {
        if (alphabetA.Length != alphabetB.Length)
        {
            throw new InvalidDataException("alphabet must have same lenght");
        }
        this.alphabetA = alphabetA;
        this.alphabetB = alphabetB;
    }

    public char crypt(char c){
        int index = Array.IndexOf(alphabetA, c);
        if (index == -1)
        {
            throw new InvalidDataException();
        }
        return alphabetB[index];
    }

    public char decrypt(char c){
        int index = Array.IndexOf(alphabetB, c);
        if (index == -1){
            throw new InvalidDataException();
        }
        return alphabetA[index];
    }
}