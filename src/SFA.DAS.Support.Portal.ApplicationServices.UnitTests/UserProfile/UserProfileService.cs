using System;
using System.Collections.Generic;

namespace SFA.DAS.Support.Portal.ApplicationServices.UnitTests.UserProfile
{
    public class UserProfileService
    {
        private readonly Dictionary<string, UserProfile> _repository = new Dictionary<string, UserProfile>();

        public UserProfile Store(string userIdentity)
        {
            var userProfile = CreateUserProfile(userIdentity);
            _repository.Add(userProfile.Identity, userProfile);
            return userProfile;
        }

        private static UserProfile CreateUserProfile(string userIdentity)
        {
            return new UserProfile() { Identity = userIdentity, FirstLogOn = DateTime.UtcNow };
        }

        public void Store(UserProfile userProfile)
        {
            if (_repository.ContainsKey(userProfile.Identity))
            {
                _repository[userProfile.Identity] = userProfile;
            }
            else
            {
                _repository.Add(userProfile.Identity, userProfile);
            }
            
        }
        public UserProfile Retrieve(string userIdentity)
        {
            return _repository.ContainsKey(userIdentity) ? 
                _repository[userIdentity] :
                CreateUserProfile(userIdentity);
        }

    }
}