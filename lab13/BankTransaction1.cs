namespace BankLibrary1
{
    public class BankTransaction
    {
        public int Summa { get; }
        public DateTime Dt { get; }
        public BankTransaction(int summa) { Summa = summa; Dt = DateTime.Now; }
        public string GetTransaction()
        {
            return Dt.ToString() + "; " + Summa.ToString();
        }
    }
}
