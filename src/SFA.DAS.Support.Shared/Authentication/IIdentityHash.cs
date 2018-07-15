namespace SFA.DAS.Support.Shared.Authentication
{
    public interface IIdentityHash
    {
        string Decrypt(string identity);
        string Encrypt(string identity);
    }
}