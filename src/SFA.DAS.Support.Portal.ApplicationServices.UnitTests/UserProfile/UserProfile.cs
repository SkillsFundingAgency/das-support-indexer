using System;

namespace SFA.DAS.Support.Portal.ApplicationServices.UnitTests.UserProfile
{
    public sealed class UserProfile
    {
        public string Identity { get; set; }
        public bool HasAgreedTermsAndConditions { get; set; }
        public DateTime? FirstLogOn { get; set; }
        public DateTime? LastLogOn { get; set; }
    }
}