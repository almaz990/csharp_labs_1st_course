class Program
{
    static void Main()
    {
        using (var account = new BankAccount())
        {
            account.Deposit(100);
            account.Withdraw(50);
            account.Deposit(100);
            
            account.GetInfo();
        }
    }

}
class BankTransaction
{
    private readonly DateTime dt;
    private readonly int summa;
    public BankTransaction(int summa) { this.summa = summa; this.dt = DateTime.Now; }
    public string GetTransaction()
    {
        return dt.ToString() + "; " + summa.ToString();
    }
}
class BankAccount : IDisposable
{
    private readonly int _number = 0;
    private int _balance = 0;
    private char _type = '0';
    private static int _accountNumberCounter = 1000;
    private Queue<BankTransaction> queue = new Queue<BankTransaction>();
    private bool _disposed = false;
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
        if (_disposed)
            throw new ObjectDisposedException("BankAccount");
        if (_balance >= money)
        {
            _balance -= money;
            BankTransaction bt = new(money);
            queue.Enqueue(bt);
        }
    }
    public void Deposit(int money)
    {
        if (_disposed)
            throw new ObjectDisposedException("BankAccount");
        _balance += money;
        BankTransaction bt = new(money);
        queue.Enqueue(bt);
    }
    public void GetInfo()
    {
        Console.WriteLine($"Info: Number = {_number}; Balance = {_balance}; Type = {_type};\nQueue = {queue.Count}");
    }
    public void Dispose()
    {
        if (_disposed) return;

        SaveTransactionsToFile();
        queue.Clear();
        _disposed = true;
        GC.SuppressFinalize(this);
    }
    private void SaveTransactionsToFile()
    {
        string path = @"Transactions.txt";
        using (StreamWriter sw = new StreamWriter(path, false))
        {
            foreach (var tr in queue)
            { sw.WriteLine(tr.GetTransaction()); }
        }
        //using (StreamReader sr = new StreamReader(path))
        //{
        //    Console.WriteLine($"{sr.ReadToEnd()}");
        //}
    }
}