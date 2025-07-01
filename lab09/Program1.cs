class Program
{
    static void Main()
    {
        BankAccount account = new ();
        BankAccount account1 = new ();

        account.GetInfo();
        account1.GetInfo();

    }
}
class BankAccount
{
    private int _number = 0;
    private int _balance = -1;
    private char _type = '0';
    private static int _accountNumberCounter = 1000;

    public BankAccount() { _number = _accountNumberCounter++; }

    public void GetInfo()
    {
        Console.WriteLine($"Info: Number = {_number}; Balance = {_balance}; Type = {_type};");
    }
    public int GetNumber() { return _number; }
    public int GetBalance() { return _balance; }
    public char GetType() { return _type; }

    
    public void SetBalance(int balance) { _balance = balance; }
    public void SetType(char type) { _type = type; }
}