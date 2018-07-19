using System;
using System.Threading.Tasks;

namespace SFA.DAS.Support.Shared.Challenge
{
    public interface IChallengeRepository<T> where T : ChallengeViewModelBase
    {
        Task<T> Retrieve(Guid challengeId);
        Task Store(T challenge);
    }
}