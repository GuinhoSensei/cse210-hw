using System;

public class Reference {
    private string _reference;
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string reference) {
        _reference = reference;
    }
    public Reference(string book, int chapter, int verse) {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
    }
    public Reference(string book, int chapter, int verse, int endVerse) {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = endVerse;
    }
    public void SetReference(string book, int chapter, int verse, int endVerse) {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = endVerse;
    }
    public string GetReference() {
        string reference = $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        return reference;
    }
}