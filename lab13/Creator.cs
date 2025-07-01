using System.Collections;

namespace BuildingLibrary
{
    public class Creator
    {
        private Creator() { }
        private static Hashtable hashtable = new Hashtable();
        public static int CreateBuild()
        {
            Building building = new();
            int number = building.Number;
            hashtable[number] = building;
            return number;
        }
        public static int CreateBuild(int height, int floors, int flats, int entrances)
        {
            Building building = new(height, floors, flats, entrances);
            int number = building.Number;
            hashtable[number] = building;
            return number;
        }
        public static void DeleteBuild(int number)
        {
            if (hashtable.ContainsKey(number))
            {
                hashtable.Remove(number);
            }
            else
            {
                Console.WriteLine($"Здание с номером {number} не существует.");
            }
        }
        public static void ReadHashtable()
        {
            foreach (DictionaryEntry de in hashtable)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }
        }
    }
}
