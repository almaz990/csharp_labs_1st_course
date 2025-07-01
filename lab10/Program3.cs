class Program
{
    static void Main()
    {
        object dateTime = DateTime.Now;
        object p = new Person();

        if (IsIFormattable(dateTime))
        {
            Console.WriteLine($"Время = {dateTime.ToString()}");
        }
        if (IsIFormattable(p))
        {
            Console.WriteLine($"Человек = {p}");
        }
        else
        {
            Console.WriteLine($"Тип {p} не реализует интерфейс IFormattable");
        }
    }
    static bool IsIFormattable(object a)
    {
        if (a is IFormattable)
        {
            IFormattable f = a as IFormattable;

            return true;
        }
        return false;
    }
}
public class Person
{
    public string name;
    public int age;
}