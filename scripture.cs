using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(" ")
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords()
    {
        // Oculta 2–3 palabras por iteración (puedes ajustar)
        int wordsToHide = 2;

        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        if (visibleWords.Count == 0)
            return;

        for (int i = 0; i < wordsToHide && visibleWords.Count > 0; i++)
        {
            int index = _rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} — {scriptureText}";
    }
}
