using System;
using System.Collections.Generic;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Challenge
{
    public class SupportAgentChallenge
    {
        public Guid Id { get; set; }
        public string Identity { get; set; }
        public string EntityType { get; set; }
        public string EntityKey { get; set; }
        public DateTimeOffset Expires { get; set; }

    }
}