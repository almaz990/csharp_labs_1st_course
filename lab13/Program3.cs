using BuildingLibrary;
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