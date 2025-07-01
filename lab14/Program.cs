class Program
{
    static void Main()
    {
        BankAccount first = new BankAccount(1000, '1');
        BankAccount second = new BankAccount(1000, '1');
        BankAccount third = new BankAccount(1001, '1');
        
        // 1.
        
        Console.WriteLine($"first == second - {first == second}");
        Console.WriteLine($"first == third - {first == third}");
        
        // 2.
        Console.WriteLine($"GetHashCode: first == second - {first.GetHashCode() == second.GetHashCode()}");
        Console.WriteLine($"GetHashCode: third == second - {third.GetHashCode() == second.GetHashCode()}");


        // 3.
        Console.WriteLine(first.ToString());
        Console.WriteLine(second.ToString());
        Console.WriteLine(third.ToString());

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
    }
    public static bool operator== (BankAccount f, BankAccount s)
    {
        return f._balance == s._balance && f._type == s._type;
    }
    public static bool operator!= (BankAccount f, BankAccount s)
    {
        return f._balance != s._balance || f._type != s._type;
    }
    public bool Equals(BankAccount obj)
    {
        if (obj is null)
            return false;
        return this._balance == obj._balance && this._type == obj._type;
    }
    public override int GetHashCode() => HashCode.Combine(_balance, _type);
    public override string ToString()
    {
        return $"Info: Number = {_number}; Balance = {_balance}; Type = {_type};\nQueue = {queue.Count}";
    }
}