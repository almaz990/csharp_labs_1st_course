using BankLibrary1;
class Program
{
    static void Main()
    {
        Bank bank = new Bank();
        bank.CreateAccount();
        bank.CreateAccount(1000);
        bank.CreateAccount('1');
        bank.CreateAccount(1000, '1');

        bank.ReadHashtable();

        bank.DeleteAccount(1001);

        Console.WriteLine();
        bank.ReadHashtable();
    }

}