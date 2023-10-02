using lab1.Encryption;
using System.Text;
using System;
using lab1;

public class MonoEncoder : ICryptable
{

    public string Encrypt(string inputText)
        => Encode(inputText, (index) => AppConstants.RussianAlphabetWithLowerCase.Length - index - 1);

    public string Decrypt(string inputText)
        => Encode(inputText, (index) => AppConstants.RussianAlphabetWithLowerCase.Length - index - 1);

    private string Encode(string text, Func<int, int> operation)
    {
        var sb = new StringBuilder();
        foreach (char c in text)
        {
            var index = AppConstants.RussianAlphabetWithLowerCase.IndexOf(c);
            sb.Append(index < 0 ? c : AppConstants.RussianAlphabetWithLowerCase[operation(index)]);
        }

        return sb.ToString();
    }
}
