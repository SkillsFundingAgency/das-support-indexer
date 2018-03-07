namespace SFA.DAS.Support.Portal.ApplicationServices.Services
{
    public interface IUserProfileService
    {
        UserProfile StoreProfileForUser(string userIdentity);
        void StoreProfileForUser(UserProfile userProfile);
        UserProfile RetrieveProfileForUser(string userIdentity);
    }
}