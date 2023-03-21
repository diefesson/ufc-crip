public class SimpleRot
{
    char[] alphabet;
    int shift;

    public SimpleRot(char[] alphabet, int shift){
        this.alphabet = alphabet;
        this.shift = shift;
    }

    public char Crypt(char c){
        int index = -1;
        for (int i = 0; i < alphabet.Length; i++){
            if (alphabet[i] == c){
                index = i;
                break;
            }
        }
        if (index == -1){
            throw new InvalidDataException($"char {c} is not part of the alphabet");
        }
        index  += shift;
        if (index >= alphabet.Length){
            index -= alphabet.Length;
        }
        return alphabet[index];
    }

    public char Decrypt(char c){
        int index = -1;
        for (int i = 0; i < alphabet.Length; i++){
            if (alphabet[i] == c){
                index = i;
                break;
            }
        }
        if (index == -1){
            throw new InvalidDataException($"char {c} is not part of the alphabet");
        }
        index -= shift;
        if (index < 0){
            index += alphabet.Length;
        }
        return alphabet[index];
    }
}