using System.Collections.Generic;

namespace SFA.DAS.Support.Portal.ApplicationServices.Services
{
    public class UserProfileRepository : IKeyedItemRepository<string, UserProfile>
    {
        private readonly Dictionary<string, UserProfile> _repository = new Dictionary<string, UserProfile>();

        public UserProfile Store(UserProfile item)
        {
            if (_repository.ContainsKey(item.Identity))
            {
                _repository[item.Identity] = item;
            }
            else
            {
                _repository.Add(item.Identity, item);
            }
            return item;
        }

        public UserProfile Retreive(string key)
        {
            return _repository.ContainsKey(key) ? _repository[key] : null;
        }

        public void Remove(string key)
        {
            if (_repository.ContainsKey(key)) _repository.Remove(key);
        }
    }
}