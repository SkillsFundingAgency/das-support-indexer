using System.Collections.Generic;

namespace SFA.DAS.Support.Portal.ApplicationServices.Services
{
    public class UserProfileRepository : IKeyedItemRepository<string, UserProfile>
    {
        private readonly Dictionary<string, UserProfile> _repository = new Dictionary<string, UserProfile>();

        public UserProfileRepository(Dictionary<string, UserProfile> repository)
        {
            _repository = repository;
        }

        public UserProfile Store(UserProfile item)
        {
            if (_repository.ContainsKey(item.Identity))
            {
                _repository.Remove(item.Identity);
            }
            _repository.Add(item.Identity, item);
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