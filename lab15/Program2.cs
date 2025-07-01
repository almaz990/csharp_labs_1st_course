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

        building.GetInfo();
        building1.GetInfo();
    }
}
class Building
{
    private static int _countBuildings = 1000;
    private readonly int _number = -1;
    
    public Building() { _number = ++_countBuildings; }
    public void GetInfo()
    {
        Console.WriteLine($@"Info: Number {_number};
      Height {Height}; Floors {Floors};
      Flats {Flats}; Entrances {Entrances};
");
    }
    public int Number { get => _number; }
    public int Height { get; set ; }
    public int Floors { get ; set ; }
    public int Flats { get ; set ; }
    public int Entrances { get ; set ; }
    public int HeightOfFloor() { return Height / Floors; }
    public int CountOfFlatsInEntrance() { return Flats / Entrances; }

}