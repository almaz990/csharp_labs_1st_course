using System.Collections;

class Program
{
    static void Main()
    {
        int building1 = Creator.CreateBuild(100, 10, 150, 5);
        int building2 = Creator.CreateBuild();
        Creator.ReadHashtable();
        Creator.DeleteBuild(building1);
        Creator.DeleteBuild(9999);
        Creator.ReadHashtable();
    }
}

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
    public static void DeleteBuild(int  number)
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

class Building
{
    private static int _countBuildings = 1000;
    private readonly int _number = -1;
    private int _height = -1, _floors = -1, _flats = -1, _entrances = -1;
    internal Building(int height, int floors, int flats, int entrances)
    {
        _number = ++_countBuildings;
        Height = height;
        Floors = floors;
        Flats = flats;
        Entrances = entrances;
    }

    internal Building() : this(-1, -1, -1, -1) { _number = ++_countBuildings; }
    public void GetInfo()
    {
        Console.WriteLine($@"Info: Number {_number};
      Height {_height}; Floors {_floors};
      Flats {_flats}; Entrances {_entrances};
");
    }
    public int Number { get => _number; }
    public int Height { get => _height; set => _height = value; }
    public int Floors { get => _floors; set => _floors = value; }
    public int Flats { get => _flats; set => _flats = value; }
    public int Entrances { get => _entrances; set => _entrances = value; }
    public int HeightOfFloor() { return _height / _floors; }
    public int CountOfFlatsInEntrance() { return _flats / _entrances; }

}