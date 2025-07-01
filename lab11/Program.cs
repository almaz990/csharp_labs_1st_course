class Program
{
    static void Main()
    {
        BankAccount account = new(1000);
        BankAccount account1 = new('1');
        BankAccount account2 = new(1000, '1');


        account.GetInfo();
        account1.GetInfo();
        account2.GetInfo();
    }
}
class BankAccount
{
    private readonly int _number = 0;
    private int _balance = 0;
    private char _type = '0';
    private static int _accountNumberCounter = 1000;

    public BankAccount(int balance, char type) 
    {
        _number = ++_accountNumberCounter;
        _balance = balance;
        _type = type;
    }
    public BankAccount(int balance) : this(balance, '0') { }
    public BankAccount(char type) : this(0, type) { }
    public BankAccount() : this(0, '0') { }
    public void Withdraw(int money) { _balance = _balance >= money ? _balance - money : _balance; }
    public void Deposit(int money) { _balance += money; }
    public void GetInfo()
    {
        Console.WriteLine($"Info: Number = {_number}; Balance = {_balance}; Type = {_type};\n");
    }
    public void Transfer(ref BankAccount sender, int summa) { this._balance += summa; sender._balance -= summa; }
}