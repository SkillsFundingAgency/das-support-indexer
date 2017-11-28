﻿using SFA.DAS.Portal.Core.Domain.Model;

namespace SFA.DAS.Portal.ApplicationServices.Responses
{
    public class AccountFinanceResponse
    {
        public Account Account { get; set; }

        public decimal Balance { get; set; }

        public SearchResponseCodes StatusCode { get; set; }
    }
}
