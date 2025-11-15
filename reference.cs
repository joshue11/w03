// Reference.cs
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    // Constructor para un solo versículo
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = verse;
    }

    // Constructor para un rango de versículos
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public string GetDisplayText()
    {
        if (_verseStart == _verseEnd)
            return $"{_book} {_chapter}:{_verseStart}";
        else
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
    }
}
