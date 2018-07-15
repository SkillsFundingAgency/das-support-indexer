namespace SFA.DAS.Support.Shared.Authentication
{
    public class IdentityHash : IIdentityHash
    {
        private readonly ICrypto _crypto;

        public IdentityHash(ICrypto crypto)
        {
            _crypto = crypto;
        }

        public string Decrypt(string identity)
        {
            return _crypto.DecryptStringAES( identity);
        }

        public string Encrypt(string identity)
        {
            return _crypto.EncryptStringAES(identity);
        }
    }
}