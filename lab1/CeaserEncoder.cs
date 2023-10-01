using System.Text;

namespace lab1
{
    class CeaserEncoder : ICryptable
    {
        private readonly int _key;

        public CeaserEncoder(int key = 1)
        {
            this._key = key;
        }

        public string Decrypt(string text) => CodeEncode(text, -_key);

        public string Encrypt(string text) => CodeEncode(text, _key);

        private string CodeEncode(string text, int k)
        {
            var fullAlfabet = AppConstants.RussianAlphabetWithLowerCase;
            var letterQty = fullAlfabet.Length;
            var sb = new StringBuilder();
            foreach (var c in text)
            {
                var index = fullAlfabet.IndexOf(c);
                sb.Append(index < 0 ? c : fullAlfabet[(letterQty + index + k) % letterQty]);
            }
            return sb.ToString();
        }
    }
}
