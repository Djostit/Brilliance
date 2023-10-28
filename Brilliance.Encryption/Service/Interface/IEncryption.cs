namespace Brilliance.Encryption.Service.Interface
{
    internal interface IEncryption
    {
        public byte[] EncryptData(string data);
        public string DecryptData(byte[] encryptedData);
    }
}
