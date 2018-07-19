namespace SFA.DAS.Support.Shared.Authentication
{
    public interface IIdentityProvider
    {
        string DefaultIdentity { get; set; }
        string ObtainIdentity();
    }
}