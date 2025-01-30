public class EncryptDecrypt
{
    public string Encrypt(string text, string key)
    {
        return Shift(text, key, true);
    }

    public string Decrypt(string text, string key)
    {
        return Shift(text, key, false);
    }

    private string Shift(string text, string key, bool encrypt)
    {
        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            int shift = key[i % key.Length];
            if (!encrypt)
            {
                shift = -shift;
            }
            letter = (char)(letter + shift);
            buffer[i] = letter;
        }
        return new string(buffer);
    }
}