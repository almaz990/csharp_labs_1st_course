using System.Collections;

namespace BankLibrary1
{
    public class Bank
    {
        private Hashtable hashtable = new Hashtable();
        public int CreateAccount(int balance, char type)
        {
            BankAccount account = new BankAccount(balance, type);
            int number = account.Number;
            hashtable[number] = account;
            return number;
        }
        public int CreateAccount(int balance)
        {
            BankAccount account = new BankAccount(balance);
            int number = account.Number;
            hashtable[number] = account;
            return number;
        }
        public int CreateAccount(char type)
        {
            BankAccount account = new BankAccount(type);
            int number = account.Number;
            hashtable[number] = account;
            return number;
        }
        public int CreateAccount()
        {
            BankAccount account = new BankAccount();
            int number = account.Number;
            hashtable[number] = account;
            return number;
        }
        public void DeleteAccount(int number)
        {
            hashtable.Remove(number);
        }
        public void ReadHashtable()
        {
            foreach (DictionaryEntry de in hashtable)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }
        }
    }
}

