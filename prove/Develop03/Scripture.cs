using System;
using System.Text;

public class Scripture {
    Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text) {
        _reference = reference;
        List<string> words =new List<string>(text.Split(' '));
        foreach (var word in words) {
            
            Word word1 = new (word);
            _words.Add(word1);
        }
    }
    public int GetWord() {
        return _words.Count();
    }
    public void HideRandomWord(int numberHide) {
        _words[numberHide].Hide();
    }
    public string Display() {

        var builder = new StringBuilder();
        foreach (Word word in _words) {
            if (word.Hidden() == true) {
                string word1 = word.GetWord();
                string space = "";
                int number = word1.Length;
                for (int i = 1; i < number; i++) {
                    space += "_";
                }
                word.SetWord(space);
                builder.Append(word.GetWord());
            }
            else {
                builder.Append(word.GetWord());
            }
        }
        string scripture = builder.ToString();
        return scripture;
    }
}