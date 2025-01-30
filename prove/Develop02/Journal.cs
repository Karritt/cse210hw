public class Journal
{
    List<Entry> _entries;
    String _filename;
    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry()
    {
        Entry entry = new Entry("", "", DateTime.Now);
        entry.NewEntry();
        _entries.Add(entry);
    }
    
    public void AddEntryNoPrompt()
    {
        Entry entry = new Entry("", "", DateTime.Now);
        entry.NewEntryNoPrompt();
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.getPrintable());
        }
    }

    public void SaveToCSV(string filename)
    {
        Console.Write("Enter Encryption Key:");
        String Key = Console.ReadLine();
        EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(encryptDecrypt.Encrypt(entry.getWritable(), Key));
            }
        }
    }
    public void LoadFromCSV(string filename)
    {
        _entries.Clear();
        Console.Write("Enter Encryption Key:");
        String Key = Console.ReadLine();
        EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
            string decryptedLine = encryptDecrypt.Decrypt(line, Key);
            string[] parts = decryptedLine.Split(',');
            DateTime entryTime = DateTime.Parse(parts[0]);
            string prompt = parts[1];
            string text = parts[2];
            Entry entry = new Entry(prompt, text, entryTime);
            _entries.Add(entry);
            Console.WriteLine("Journal loaded!");
            }
        }
    }
}