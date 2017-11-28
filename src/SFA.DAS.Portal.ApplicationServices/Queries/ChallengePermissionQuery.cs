﻿using MediatR;
using SFA.DAS.Portal.ApplicationServices.Responses;
using SFA.DAS.Portal.Core.Domain.Model;

namespace SFA.DAS.Portal.ApplicationServices.Queries
{
    public class ChallengePermissionQuery : IAsyncRequest<ChallengePermissionResponse>
    {
        public string Id { get; private set; }

        public string Url { get; set; }

        public string ChallengeElement1 { get; set; }

        public string ChallengeElement2 { get; set; }

        public string Balance { get; set; }

        public string FirstCharacterPosition { get; set; }

        public string SecondCharacterPosition { get; set; }

        public ChallengePermissionQuery(ChallengeEntry challengeEntry)
        {
            Id = challengeEntry.Id;
            Url = challengeEntry.Url;
            ChallengeElement1 = challengeEntry.Challenge1;
            ChallengeElement2 = challengeEntry.Challenge2;
            Balance = challengeEntry.Balance;
            FirstCharacterPosition = challengeEntry.FirstCharacterPosition;
            SecondCharacterPosition = challengeEntry.SecondCharacterPosition;
        }
    }
}