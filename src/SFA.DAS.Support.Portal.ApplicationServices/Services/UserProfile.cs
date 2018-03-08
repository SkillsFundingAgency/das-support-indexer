using System;

namespace SFA.DAS.Support.Portal.ApplicationServices.Services
{
    public sealed class UserProfile
    {
        public string Identity { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset? AgreedTermsAndConditions { get; set; } 
    }
}