using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.DAS.Support.Shared.Challenge
{
    public class InMemoryChallengeService : IChallengeService
    {
        private readonly Dictionary<Guid, SupportAgentChallenge> _challenges;
        private readonly IChallengeSettings _configuration;

        public InMemoryChallengeService(Dictionary<Guid, SupportAgentChallenge> challenges,
            IChallengeSettings configuration)
        {
            _challenges = challenges;
            _configuration = configuration;
            ChallengeMaxRetries = _configuration.ChallengeMaxRetries;
        }


        public int ChallengeMaxRetries { get; set; }

        public async Task<Guid> IsNeeded(string identity, string entityType, string entityKey)
        {
            if (_challenges.Values.FirstOrDefault(x =>
                    x.Identity == identity
                    && x.EntityType == entityType
                    && x.EntityKey == entityKey
                    && x.Expires > DateTimeOffset.UtcNow) == null)
            {
                var challenge = new SupportAgentChallenge
                {
                    Id = Guid.NewGuid(),
                    Identity = identity,
                    EntityType = entityType,
                    EntityKey = entityKey,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(_configuration.ChallengeExpiryMinutes)
                };
                _challenges.Add(challenge.Id, challenge);
                return await Task.FromResult(challenge.Id);
            }

            return await Task.FromResult(Guid.Empty);
        }

        public Task Store(SupportAgentChallenge challenge)
        {
            if (_challenges.ContainsKey(challenge.Id))
                _challenges[challenge.Id] = challenge;
            else
                _challenges.Add(challenge.Id, challenge);

            return Task.CompletedTask;
        }

        public int ChallengeExpiryMinutes { get; set; }
    }
}