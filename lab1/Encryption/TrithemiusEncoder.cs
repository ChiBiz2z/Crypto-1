using System;
using System.Text;

namespace lab1.Encryption;

public class TrithemiusEncoder : ICryptable
{
    private readonly string _key;

    public TrithemiusEncoder(string key)
        => _key = string.IsNullOrEmpty(key) ? "ключ" : key;

    public string Encrypt(string text) => Encode(text, (index, keyIndex) =>
    (index + keyIndex) % AppConstants.RussianAlphabet.Length);

    public string Decrypt(string text) => Encode(text, (index, keyIndex) =>
    (index - keyIndex) % AppConstants.RussianAlphabet.Length);


    private string Encode(string text, Func<int, int, int> operation)
    {
        var sb = new StringBuilder();
        var fullAlphabet = AppConstants.RussianAlphabet.ToLower();
        for (int i = 0; i < text.Length; i++)
        {
            var ch = text[i];
            var index = fullAlphabet.IndexOf(ch);
            var kI = fullAlphabet.IndexOf(_key[i % _key.Length]);
            sb.Append(index < 0 ? ch : fullAlphabet[operation(index, kI)]);
        }

        return sb.ToString();
    }
}