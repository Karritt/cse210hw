using System.Net.Http;
using System.Threading.Tasks;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private int _wordCount;
    private int _hiddenWordCount;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
        _wordCount = _words.Count;
        _hiddenWordCount = 0;
    }

    public Scripture(Reference reference)
    {
        var client = new HttpClient();
        string query = $"https://openscriptureapi.org/api/scriptures/v1/lds/en/book/{reference.GetBook().ToLower().Replace(" ","")}/{reference.GetChapter()}";
        // Console.WriteLine(query);

        var response = client.GetAsync(query).Result;
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            dynamic scriptureData = System.Text.Json.JsonDocument.Parse(jsonResponse).RootElement;
            var versesArray = scriptureData.GetProperty("chapter").GetProperty("verses").EnumerateArray();
            List<dynamic> versesList = [.. versesArray];
            int startVerse = int.Parse(reference.GetStartVerse());
            int endVerse = int.Parse(reference.GetEndVerse());
            string text = string.Empty;
            for (int i = startVerse; i <= endVerse; i++)
            {
                text += i.ToString()+ " " + versesList[i - 1].GetProperty("text").GetString() + " \n\n ";
            }
            _words = new List<Word>();
            string[] words = text.Split(' ');
            foreach (string word in words)
            {
                Word newWord = new Word(word);
                _words.Add(newWord);
            }
            _wordCount = _words.Count;
            _hiddenWordCount = 0;
            _reference = reference;
        }
        else
        {
            var errorResponse = response.Content.ReadAsStringAsync().Result;
            throw new Exception($"Unable to retrieve scripture text. Response: {errorResponse}");
        }
    }
    public void Display ()
    {
        Console.WriteLine(_reference.GetFormatted());
        foreach (Word word in _words)
        {
            Console.Write(word.GetText() + " ");
        }
        Console.WriteLine();
    }
    public void Reset ()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
        _hiddenWordCount = 0;
    }

    public void HideWords(int count)
    {
        if (count + _hiddenWordCount > _wordCount)
        {
            count = _wordCount - _hiddenWordCount;
        }
        _hiddenWordCount += count;
        if (count == 0) 
        {
            Reset();
        } 
        else
        {
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(_words.Count);
                if (!_words[index].isHidden())
                {
                    _words[index].Hide();
                }
                else
                {
                    i--;
                }
            }
        }
    }
}