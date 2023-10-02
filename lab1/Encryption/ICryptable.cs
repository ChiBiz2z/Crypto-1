namespace lab1.Encryption
{
    interface ICryptable
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
