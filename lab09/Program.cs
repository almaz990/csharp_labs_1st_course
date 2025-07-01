class Program
{
    static void Main()
    {
        BankAccount account = new();

        account.SetNumber("12345");
        account.SetBalance(999);
        account.SetType('1');

        account.GetInfo();
    }
}
class BankAccount
{
    private string number = "Unknown";
    private int balance = -1;
    private char type = '0';
    public void GetInfo()
    {
        Console.WriteLine($"Info: Number = {number}; Balance = {balance}; Type = {type};");
    }
    public string GetNumber() { return number; }
    public int GetBalance() { return balance; }
    public char GetType() { return type; }

    public void SetNumber(string number) { this.number = number; }
    public void SetBalance(int balance) { this.balance = balance; }
    public void SetType(char type) { this.type = type; }
}