class Program
{
    static void Main()
    {

        string[] names = { "Hotel California", "Billie Jean", "Rolling in the Deep", "Sweet Child O' Mine" };
        string[] authors = { "Eagles", "Michael Jackson", "Adele", "Guns N' Roses" };
        List<Song> songs = new List<Song>();

        for (int i = 0; i < names.Length; i++)
        {
            Song song = new Song();
            song.SetName(names[i]);
            song.SetAuthor(authors[i]);
            song.PrintInfo();
            songs.Add(song);

        }
        if (songs[0].Equals(songs[1]))
        {
            Console.WriteLine("Первая песня равно второй");
        }
        else { Console.WriteLine("Песня 1 и песня 2 не равны"); }
    }
}
class Song
{
    string name;
    string author;
    Song prev;
    public void SetName(string name) { this.name = name; }
    public void SetAuthor(string author) { this.author = author; }
    public void SetPrev(Song prev) { this.prev = prev; }
    public void PrintInfo()
    {
        Console.WriteLine($"Название: {name};\t\t Автор: {author}");
    }
    public string Title() { return name + " " + author; }
    public override bool Equals(object d) { Song s = (Song)d;  return name == s.name && author == s.author; }
}