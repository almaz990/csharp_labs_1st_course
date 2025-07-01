class Program
{
    static void Main()
    {
        //1
        Cipher cipher = new ACipher();
        
        Console.WriteLine(cipher.Encode("ABCDEFG"));
        Console.WriteLine(cipher.Decode("BCDEFGH"));
        Console.WriteLine();
        //2
        Cipher cipher1 = new BCipher();

        Console.WriteLine(cipher1.Encode("ABCD"));
        Console.WriteLine(cipher1.Decode("ZYXW"));
        Console.WriteLine();
    }
}
interface ICipher 
{

    string Encode(string s);
    string Decode(string s);
}
abstract class Cipher : ICipher
{
    public abstract string Encode(string s);
    public abstract string Decode(string s);
}
class ACipher : Cipher
{

    public override string Encode(string s)
    {
        string r = "";
        foreach (char el in s)
        {
            r += (char)(el + 1);
            
        }
        return r;
    }
    public override string Decode(string s)
    {

        string r = "";
        foreach (char el in s)
        {
            r += (char)(el - 1);

        }
        return r;
    }
}
class BCipher : Cipher
{

    public override string Encode(string s) => Shifr(s);

    public override string Decode(string s) => Shifr(s);
    private string Shifr(string s)
    {
        string r = "";
        for (int i = 0; i < s.Length; i++)
        {
            r += (char)(90 - (int)(s[i]) % 65);
        }
        return r;
    }
}