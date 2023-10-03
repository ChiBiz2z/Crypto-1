using lab1;
using lab1.Encryption;
using System.Linq;
using System.Text;

public class MonoEncoder : ICryptable
{
    private readonly string ReverseAlphabet = new string(AppConstants.RussianAlphabetWithLowerCase.Reverse().ToArray());

    public string Encrypt(string inputText)
        => Encode(inputText, AppConstants.RussianAlphabetWithLowerCase, ReverseAlphabet);

    public string Decrypt(string inputText)
        => Encode(inputText, ReverseAlphabet, AppConstants.RussianAlphabetWithLowerCase);

    private string Encode(string text, string fromAlphabet, string toAlphabet)
    {
        var sb = new StringBuilder();
        foreach (char c in text)
        {
            var index = fromAlphabet.IndexOf(c);
            sb.Append(index < 0 ? c : toAlphabet[index]);
        }

        return sb.ToString();
    }
}
