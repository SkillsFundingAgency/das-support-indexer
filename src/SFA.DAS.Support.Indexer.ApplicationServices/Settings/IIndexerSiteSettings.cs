using SFA.DAS.Support.Shared.SiteConnection;

namespace SFA.DAS.Support.Indexer.ApplicationServices.Settings
{
    public interface IIndexerSiteSettings: ISiteSettings
    {
        string DelayTimeInSeconds { get; set; }
    }
}