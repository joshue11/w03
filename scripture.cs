// Scripture.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Dividimos en tokens por espacios (preserva puntuación unida a la palabra)
        string[] tokens = text.Split(' ');
        foreach (string token in tokens)
        {
            _words.Add(new Word(token));
        }
    }

    // Oculta hasta 'count' palabras, eligiendo sólo entre las que NO están ocultas.
    // Si no hay suficientes palabras visibles, oculta las que queden.
    public void HideRandomWords(int count)
    {
        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
                visibleIndexes.Add(i);
        }

        if (visibleIndexes.Count == 0)
            return;

        // Si count es mayor que las visibles, limitamos
        int toHide = Math.Min(count, visibleIndexes.Count);

        for (int i = 0; i < toHide; i++)
        {
            int pick = _random.Next(visibleIndexes.Count);
            int index = visibleIndexes[pick];
            _words[index].Hide();
            visibleIndexes.RemoveAt(pick); // evitar volver a elegir la misma
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        // Construimos la línea de palabras unidas por espacios
        string line = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{line}";
    }
}
