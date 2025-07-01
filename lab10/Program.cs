class Program
{
    static void Main()
    {
        BankAccount account = new();
        BankAccount account1 = new();

        account.Balance = 1000;
        account1.Balance = 2000;

        account.Transfer(ref account1, 750);

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
        Console.WriteLine($"Info: Number = {_number}; Balance = {_balance}; Type = {_type};\n");
    }

    public void Transfer(ref BankAccount sender, int summa) { this._balance += summa; sender._balance -= summa; }

    public int Number { get => _number; }
    public int Balance { get => _balance; set => _balance = value; }
    public char Type { get => _type; set => _type = value; }

}