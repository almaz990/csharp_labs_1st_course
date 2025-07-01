class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();
        BankAccount bankAccount = new BankAccount();

        account.Deposit(100);
        account.Deposit(100);
        account.Withdraw(100);

        bankAccount.Deposit(50);
        bankAccount.Deposit(50);

        account.GetInfo();
        bankAccount.GetInfo();
    }

 }
class BankTransaction
{
    private readonly DateTime dt;
    private readonly int summa;
    public BankTransaction(int summa) { this.summa = summa; this.dt = DateTime.Now; }
}
class BankAccount
{
    private readonly int _number = 0;
    private int _balance = 0;
    private char _type = '0';
    private static int _accountNumberCounter = 1000;
    private Queue<BankTransaction> queue = new Queue<BankTransaction>();
    public BankAccount(int balance, char type)
    {
        _number = ++_accountNumberCounter;
        _balance = balance;
        _type = type;
    }
    public BankAccount(int balance) : this(balance, '0') { }
    public BankAccount(char type) : this(0, type) { }
    public BankAccount() : this(0, '0') { }
    public void Withdraw(int money) 
    {
        if (_balance >= money)
        {
            _balance -= money;
            BankTransaction bt = new(-money);
            queue.Enqueue(bt);
        }
    }
    public void Deposit(int money) 
    {   
        _balance += money;
        BankTransaction bt = new(money);
        queue.Enqueue(bt);
    }
    public void GetInfo()
    {
        Console.WriteLine($"Info: Number = {_number}; Balance = {_balance}; Type = {_type};\nQueue = {queue.Count}");
    }
}