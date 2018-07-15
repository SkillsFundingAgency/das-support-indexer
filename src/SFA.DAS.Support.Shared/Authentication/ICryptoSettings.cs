namespace SFA.DAS.Support.Shared.Authentication
{
    public interface ICryptoSettings
    {
        string Salt { get; set; }
        string Secret { get; set; }
    }
}