class Program
{
    static void Main()
    {
        

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
    
    private int _balance = 0;
    public string Holder { get; set; }
    public int Number { get; }
    public char Type { get; }

    private static int _accountNumberCounter = 1000;
    private Queue<BankTransaction> queue = new Queue<BankTransaction>();
    private bool _disposed = false;
    public BankAccount(int balance, char type)
    {
        Number = ++_accountNumberCounter;
        _balance = balance;
        Type = type;
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
        Console.WriteLine($"Info: Number = {Number}; Balance = {_balance}; Type = {Type};\nQueue = {queue.Count}");
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
    public static bool operator ==(BankAccount f, BankAccount s)
    {
        return f._balance == s._balance && f.Type == s.Type;
    }
    public static bool operator !=(BankAccount f, BankAccount s)
    {
        return f._balance != s._balance || f.Type != s.Type;
    }
    public bool Equals(BankAccount obj)
    {
        if (obj is null)
            return false;
        return this._balance == obj._balance && this.Type == obj.Type;
    }
    public override int GetHashCode() => HashCode.Combine(_balance, Type);
    public override string ToString()
    {
        return $"Info: Number = {Number}; Balance = {_balance}; Type = {Type};\nQueue = {queue.Count}";
    }
}