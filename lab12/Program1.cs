using System.Drawing;

class Program
{
    static void Main()
    {
        Figure point = new Point(3, 5);

        point.HorizontalMove(3);
        point.VerticalMove(5);
        point.Condition = "invisible";
        point.Colour = "black";
        point.PrintObject();
        
        Figure circle = new Circle(5);

        circle.HorizontalMove(10);
        circle.VerticalMove(2);
        circle.Condition = "visible";
        circle.Colour = "white";

        Console.WriteLine($"Площадь окружности: {circle.Square()}");
        circle.PrintObject();

        Figure rectangle = new Rectangle(5, 6);
        rectangle.Condition = "visible";
        rectangle.Colour = "yellow";

        Console.WriteLine($"Площадь прямоугольника: {rectangle.Square()}");
        rectangle.PrintObject();

    }
}
interface IFigure
{
    void HorizontalMove(int x);
    void VerticalMove(int y);
    void ChangeColour(string newColour);
    public double Square();
    void PrintObject();
}

abstract class Figure : IFigure
{
    protected string colour, condition;
    public string Colour { get =>  colour; set => colour = value; }
    public string Condition { get => condition; set => condition = value; }
    public abstract void HorizontalMove(int x);
    public abstract void VerticalMove(int y);
    public abstract double Square();
    public abstract void ChangeColour(string newColour);
    public virtual void PrintObject()
    {
        Console.WriteLine($"Condition: {condition}, Colour: {colour}");
    }
}

class Point : Figure
{
    protected int x, y;
    public Point() { }
    public Point(int x, int y)
    {
        this.x = x; this.y = y;
    }
    public override void HorizontalMove(int x)
    {
        this.x += x;
    }
    public override void VerticalMove(int y)
    {
        this.y += y;
    }
    public override void ChangeColour(string colour)
    {
        this.colour = colour;
    }
    public override void PrintObject()
    {
        Console.WriteLine($"Condition: {condition}, Colour: {colour}, (x, y): ({x}, {y})");
    }
    public override double Square() { return 0.0; }
}

class Circle : Point
{
    int r;
    public Circle(int r) => this.r = r;
    public void ChangeR(int r) => this.r = r;
    public override double Square()
    {
        return double.Pi * r*r;
    }

}

class Rectangle : Point
{
    public Rectangle(int a, int b)
    {
        this.a = a;
        this.b = b;
    }
    int a, b;
    public void ChangeA(int a)
    {
        this.a = a;
    }
    public void ChangeB(int b)
    {
        this.b = b;
    }
    public override double Square()
    {
        return a * b;
    }
}

