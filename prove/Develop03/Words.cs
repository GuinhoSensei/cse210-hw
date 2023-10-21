using System;

public class Word {
    private string _text;
    private bool _hidden = !true;

    public Word(string text) {
        _text = text;
    }
    public void SetWord(string text) {
        _text = text;
    }
    public void Hide() {
        _hidden = true;
    }
    public void Show() {
        _hidden = false;
    }
    public bool Hidden () {
        return _hidden;
    }
    public string GetWord() {
        string text = $"{_text} ";
        return text;
    }
}