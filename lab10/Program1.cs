class Program
{
    static void Main()
    {
        string s = "abcdefg";
        Console.WriteLine(Reverse(s));
    }
    static string Reverse(string input)
    {
        string output = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            output += input[i];
        }

        return output;
    }
}