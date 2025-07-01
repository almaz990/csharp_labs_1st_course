class Program
{
    static void Main()
    {

        var books = new[]
        {
            new Book("CLR via C#", "Джеффри Рихтер", "Питер"),
            new Book("Чистый код", "Роберт Мартин", "БХВ"),
            new Book("Паттерны проектирования", "Эрих Гамма", "Вильямс")
        };
        var library = new ContainerBook(books);

        Console.WriteLine("Выберите критерий сортировки: ");
        var criteria = Console.ReadLine();

        switch(criteria)
        {
            case "author": library.SortBooks(BookComparison.CompareAuthor); library.PrintBooks(); break;
            case "title": library.SortBooks(BookComparison.CompareTitle); library.PrintBooks(); break;
            case "publisher": library.SortBooks(BookComparison.ComparePublisher); library.PrintBooks(); break;
            default: Console.WriteLine("Выберите из списка: (author), (title), (publisher)"); break;
        }
    }
}

class Book
{
    public string Title { get; }
    public string Author { get; }
    public string Publisher { get; }

    public Book(string title, string author, string publisher)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
    }

}
class ContainerBook
{
    private Book[] _books;
    public ContainerBook(Book[] books) { _books = books; }
    public void SortBooks(CompareBooks cb)
    {
        for (int i = 0; i < _books.Length - 1; i++)
        {
            for (int j = i + 1; j < _books.Length; j++)
            {
                if (cb(_books[i], _books[j]) > 0)
                {
                    var t = _books[i];
                    _books[i] = _books[j];
                    _books[j] = t;
                }
            }
        }
    }
    public void PrintBooks()
    {
        foreach (var book in _books)
        {
            Console.WriteLine($"{book.Title} | {book.Author} | {book.Publisher}");
        }
    }
}
class BookComparison
{
    public static int CompareTitle(Book f, Book s)
    {
        return string.Compare(f.Title, s.Title);
    }
    public static int CompareAuthor(Book f, Book s)
    {
        return string.Compare(f.Author, s.Author);
    }
    public static int ComparePublisher(Book f, Book s)
    {
        return string.Compare(f.Publisher, s.Publisher);
    }
}

delegate int CompareBooks(Book f, Book s);