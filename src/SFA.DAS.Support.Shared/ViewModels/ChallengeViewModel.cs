using System;

namespace SFA.DAS.Support.Shared.ViewModels
{
    public class ChallengeViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string EntityType { get; set; }
        public string Identifier { get; set; }
        public string Identity { get; set; }
        public DateTimeOffset Until { get; set; }
        public int Tries { get; set; }
    }
}