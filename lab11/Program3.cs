class Program
{
    static void Main()
    {
        Song mySong = new Song();
    }
}
class Song
{
    string name;
    string author;
    Song? prev;
    public Song() { }
    public Song(string name, string author)
    {
        this.name = name;
        this.author = author;
        this.prev = null;
    }
    public Song(string name, string author, Song prev)
    {
        this.name = name;
        this.author = author;
        this.prev = prev;
    }

    public void SetName(string name) { this.name = name; }
    public void SetAuthor(string author) { this.author = author; }
    public void SetPrev(Song prev) { this.prev = prev; }
    public void PrintInfo()
    {
        Console.WriteLine($"Название: {name};\t\t Автор: {author}");
    }
    public string Title() { return name + " " + author; }
    public override bool Equals(object d) { Song s = (Song)d; return name == s.name && author == s.author; }




}