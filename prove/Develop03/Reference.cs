public class Reference
{
    private string _book;
    private string _chapter;
    private string _startVerse;
    private string _endVerse;

    public Reference()
    {
        Console.WriteLine("Enter the book:");
        _book = Console.ReadLine();
        Console.WriteLine("Enter the chapter:");
        _chapter = Console.ReadLine();
        Console.WriteLine("Enter the starting verse:");
        _startVerse = Console.ReadLine();
        Console.WriteLine("Enter the ending verse (Default None):");
        _endVerse = Console.ReadLine();
        if (_endVerse == "")
        {
            _endVerse = _startVerse;
        }
    }

    public Reference(string book, string chapter, string startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = startVerse;
    }
    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetFormatted()
    {
        return _book + " " + _chapter + ":" + _startVerse + (_startVerse == _endVerse ? "" : "-" + _endVerse);
    }

    public string GetBook()
    {
        return _book;
    }

    public string GetChapter()
    {
        return _chapter;
    }

    public string GetVerses()
    {
        return _startVerse + (_startVerse == _endVerse ? "" : "-" + _endVerse);
    }
    public string GetStartVerse()
    {
        return _startVerse;
    }
    public string GetEndVerse()
    {
        return _endVerse;
    }
}