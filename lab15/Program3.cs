class Program
{
    static void Main()
    {
        Building building = new();
        Building building1 = new();

        building.Height = 100;
        building.Floors = 10;
        building.Flats = 150;
        building.Entrances = 5;

        Building[] b = {building, building1};

        Buildings buildings = new(b);

        buildings[0].GetInfo();
    }
}
class Building
{
    private static int _countBuildings = 1000;
    private readonly int _number = -1;
    private int _height = -1, _floors = -1, _flats = -1, _entrances = -1;
    public Building() { _number = ++_countBuildings; }
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

class Buildings
{
    Building[] buildings = new Building[10];
    public Buildings(Building[] b) => buildings = b;
    public Building this[int idx]
    {
        get => buildings[idx];
        set => buildings[idx] = value;
    }
    
}