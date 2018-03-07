using System;

namespace SFA.DAS.Support.Portal.ApplicationServices.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IKeyedItemRepository<string, UserProfile> _repository;

        public UserProfileService(IKeyedItemRepository<string, UserProfile> repository)
        {
            _repository = repository;
        }

        public UserProfile StoreProfileForUser(string userIdentity)
        {
            var userProfile = CreateUserProfile(userIdentity);
            return _repository.Store(userProfile);
        }

        private static UserProfile CreateUserProfile(string userIdentity)
        {
            return new UserProfile() { Identity = userIdentity, Created = DateTimeOffset.UtcNow };
        }

        public void StoreProfileForUser(UserProfile userProfile)
        {
            _repository.Store(userProfile);

        }

        public UserProfile RetrieveProfileForUser(string userIdentity)
        {
            return _repository.Retreive(userIdentity); ;
        }

    }
}