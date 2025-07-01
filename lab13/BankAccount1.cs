namespace BankLibrary1
{
    public class BankAccount : IDisposable
    {
        private int _balance = 0;
        public string Holder { get; set; }
        public int Number { get; }
        public char Type { get; }
        private static int _accountNumberCounter = 1000;

        private Queue<BankTransaction> queue = new Queue<BankTransaction>();
        private List<BankTransaction> Transactions = new List<BankTransaction>();
        private bool _disposed = false;
        internal BankAccount(int balance, char type)
        {
            Number = ++_accountNumberCounter;
            _balance = balance;
            Type = type;
        }
        internal BankAccount(int balance) : this(balance, '0') { }
        internal BankAccount(char type) : this(0, type) { }
        internal BankAccount() : this(0, '0') { }
        public void Withdraw(int money)
        {
            if (_disposed)
                throw new ObjectDisposedException("BankAccount");
            if (_balance >= money)
            {
                _balance -= money;
                BankTransaction bt = new(money);
                Transactions.Add(bt);

                queue.Enqueue(bt);
            }
        }
        public void Deposit(int money)
        {
            if (_disposed)
                throw new ObjectDisposedException("BankAccount");
            _balance += money;
            BankTransaction bt = new(money);
            Transactions.Add(bt);
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
            Transactions.Clear();
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
        public BankTransaction this[int idx]
        {
            get => Transactions[idx];
            set => Transactions[idx] = value;
        }
    }
}
