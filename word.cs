// Word.cs
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

    // Oculta la palabra
    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Devuelve la representación a mostrar:
    // - si está oculta, devuelve tantos '_' como caracteres tenga la palabra (mantiene longitud)
    // - si no, devuelve el texto original
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Reemplazamos cada carácter alfanumérico por '_' para mantener puntuación si existiera.
            var sb = new StringBuilder();
            foreach (char c in _text)
            {
                // Si quieres contar solo letras/dígitos como longitud, cambia esta condición.
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
