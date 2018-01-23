﻿using System.Collections.Generic;

namespace SFA.DAS.Support.Portal.Web.Helpers
{
    public class ChallengeHelper
    {
        public static string GetChallengeMessage(List<int> challengeCharacters)
        {
            return
                $"{DisplayCharacter(challengeCharacters[0])} & {DisplayCharacter(challengeCharacters[1])} character of a PAYE scheme (excluding the /):";
        }

        private static string DisplayCharacter(int challengeCharacter)
        {
            challengeCharacter = challengeCharacter + 1;

            var check = 0;
            if (challengeCharacter < 20)
            {
                check = challengeCharacter;
            }
            else
            {
                var multiplier = challengeCharacter / 20;
                check = challengeCharacter - multiplier * 20;
            }

            var response = string.Empty;

            switch (check)
            {
                case 1:
                    response = $"{challengeCharacter}st";
                    break;
                case 2:
                    response = $"{challengeCharacter}nd";
                    break;
                case 3:
                    response = $"{challengeCharacter}rd";
                    break;
                default:
                    response = $"{challengeCharacter}th";
                    break;
            }

            return response;
        }
    }
}