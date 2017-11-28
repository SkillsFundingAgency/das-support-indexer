﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFA.DAS.EAS.Account.Api.Types;
using SFA.DAS.Portal.ApplicationServices;
using SFA.DAS.Portal.ApplicationServices.Queries;
using SFA.DAS.Portal.Core.Domain.Model;

namespace SFA.DAS.Portal.Infrastructure
{
    public class ChallengeRepository : IChallengeRepository
    {
        private readonly IAccountRepository _accountRepository;

        public ChallengeRepository(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> CheckData(Account record, ChallengePermissionQuery message)
        {
            var balance = await _accountRepository.GetAccountBalance(message.Id);

            var validPayeSchemesData = CheckPayeSchemesData(record.PayeSchemes, message);

            decimal messageBalance;

            if (!decimal.TryParse(message.Balance.Replace("£", string.Empty), out messageBalance))
            {
                return false;
            }

            return Math.Truncate(balance) == Math.Truncate(Convert.ToDecimal(messageBalance)) && validPayeSchemesData;
        }

        private bool CheckPayeSchemesData(IEnumerable<PayeSchemeViewModel> recordPayeSchemes, ChallengePermissionQuery message)
        {
            var challengeInput = new List<string>
            {
                message.ChallengeElement1.ToLower(),
                message.ChallengeElement2.ToLower()
            };

            return recordPayeSchemes.Select(payeSchemeViewModel => payeSchemeViewModel.Ref.Replace("/", string.Empty)).Any(payeSchemaRef => payeSchemaRef[int.Parse(message.FirstCharacterPosition)].ToString().ToLower() == challengeInput[0] && payeSchemaRef[int.Parse(message.SecondCharacterPosition)].ToString().ToLower() == challengeInput[1]);
        }
    }
}
