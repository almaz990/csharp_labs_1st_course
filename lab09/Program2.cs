class Program
{
    static void Main()
    {
        BankAccount account = new();
        BankAccount account1 = new();

        account.SetBalance(999);
        account1.SetBalance(999);

        account.Deposit(100);
        account1.Deposit(101);

        account.Withdraw(1100);
        account1.Withdraw(1100);

        account.GetInfo();
        account1.GetInfo();

    }
}
class BankAccount
{
    private readonly int _number = 0;
    private int _balance = -1;
    private char _type = '0';
    private static int _accountNumberCounter = 1000;

    public BankAccount() { _number = ++_accountNumberCounter; }

    public void Withdraw(int money) { _balance = _balance >= money ? _balance - money : _balance; }
    public void Deposit(int money) { _balance += money; }
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