namespace SFA.DAS.Support.Shared.Challenge
{
    public class ChallengeSettings : IChallengeSettings
    {
        public int ChallengeExpiryMinutes { get; set; } = 10;
        public int ChallengeMaxRetries { get; set; } = 3;
    }
}