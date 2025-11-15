using System;
using System.Text;
using System.Text.RegularExpressions;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            var sb = new StringBuilder();
            foreach (char c in _text)
            {
                if (Char.IsWhiteSpace(c))
                    sb.Append(c);
                else
                    sb.Append('_');
            }
            return sb.ToString();
        }
        return _text;
    }
}
