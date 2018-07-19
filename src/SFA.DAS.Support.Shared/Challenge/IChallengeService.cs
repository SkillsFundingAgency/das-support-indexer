using System;
using System.Threading.Tasks;

namespace SFA.DAS.Support.Shared.Challenge
{
    public interface IChallengeService
    {
        int ChallengeExpiryMinutes { get; set; }

        int ChallengeMaxRetries { get; set; }

        Task<Guid> IsNeeded(
            string identity,
            string entityType,
            string entityKey
        );

        Task Store(SupportAgentChallenge challenge);
    }
}