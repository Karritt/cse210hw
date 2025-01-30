public class Entry
{
    string _text;
    DateTime _entryTime;
    string _prompt;
    string _author;
    public Entry (String prompt, String text, DateTime entryTime) {
        _prompt = prompt;
        _text = text;
        _entryTime = entryTime;
        _author = "";
        
    }
    public void NewEntry() {
        PromptGenerator promptGenerator = new PromptGenerator();
        String prompt = promptGenerator.GetPrompt();
        Console.WriteLine(prompt);
        String text = Console.ReadLine();
        DateTime entryTime = DateTime.Now;
        _prompt = prompt;
        _text = text;
        _entryTime = entryTime;
        _author = "";
    }

    public void NewEntryNoPrompt() {
        String text = Console.ReadLine();
        DateTime entryTime = DateTime.Now;
        _text = text;
        _entryTime = entryTime;
        _author = "";
        _prompt = "";
    }

    public string getPrintable() {
        return _entryTime + " " + _prompt + "\n" + _text;
    }
    public string getWritable() {
        return _entryTime + "," + _prompt + "," + _text;
    }
}