namespace SFA.DAS.Support.Shared.Challenge
{
    public interface IChallengeSettings
    {
        int ChallengeMaxRetries { get; set; }
        int ChallengeExpiryMinutes { get; set; }
    }
}