public class Word
{
    private string _text;
    private string _blankedText;
    private bool _isBlanked;

    public Word(string text)
    {
        _text = text;
        if (text == "\n\n")
        {
            _blankedText = "\n\n";
        }
        else
        {
            _blankedText = new string('_', text.Length);
        }
        _isBlanked = false;
    }

    public void Hide()
    {
        _isBlanked = true;
    }
    public void Show()
    {
        _isBlanked = false;
    }
    public string GetText()
    {
        if (_isBlanked)
        {
            return _blankedText;
        }
        else
        {
            return _text;
        }
    }

    public bool isHidden()
    {
        return _isBlanked;
    }
}