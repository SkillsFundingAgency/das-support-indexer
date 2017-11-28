﻿using System;
using System.Collections.Generic;
using System.Linq;
using SFA.DAS.EAS.Account.Api.Types;

namespace SFA.DAS.Portal.ApplicationServices.Services
{
    public class ChallengeService : IChallengeService
    {
        public List<int> GetPayeSchemesCharacters(IEnumerable<PayeSchemeViewModel> payeSchemes)
        {
            var schemes = payeSchemes.Select(payeSchemeViewModel => payeSchemeViewModel.Ref.Substring(1, payeSchemeViewModel.Ref.Length - 2).Replace("/", string.Empty)).ToList();

            var range = GetMinimumNumberOfCharacters(schemes);

            var response = GetRandomPositions(range + 1);

            response.Sort();

            return response;
        }

        private List<int> GetRandomPositions(int range)
        {
            var r = new Random();
            var random1 = r.Next(1, range);

            int random2;

            do
            {
                random2 = r.Next(1, range);
            } while (random1 == random2);

            return new List<int>
            {
                random1,
                random2
            };
        }

        private int GetMinimumNumberOfCharacters(IEnumerable<string> schemes)
        {
            return schemes.Select(scheme => scheme.Length).Min();
        }
    }
}