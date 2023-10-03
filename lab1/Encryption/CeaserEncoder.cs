using System.Text;

namespace lab1.Encryption
{
    class CeaserEncoder : ICryptable
    {
        private readonly int _key;

        public CeaserEncoder(int key = 1)
        {
            _key = key;
        }

        public string Decrypt(string text) => CodeEncode(text, -_key);//Дешифрование текста с использованием отрицательного ключа

        public string Encrypt(string text) => CodeEncode(text, _key);//Дешифрование текста с использованием  ключа

        private string CodeEncode(string text, int k)
        {
            var fullAlphabet = AppConstants.RussianAlphabetWithLowerCase; // Алфавит русского языка с большими и маленькими буквами
            var letterQty = fullAlphabet.Length;
            var sb = new StringBuilder();
            foreach (var c in text)
            {
                var index = fullAlphabet.IndexOf(c);
                sb.Append(index < 0 ? c : fullAlphabet[(letterQty + index + k) % letterQty]); //E(x) = (x +/- k) mod n
            }
            return sb.ToString();
        }
    }
}
