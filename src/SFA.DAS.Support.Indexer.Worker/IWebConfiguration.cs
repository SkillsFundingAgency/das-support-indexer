using SFA.DAS.Support.Common.Infrastucture.Settings;
using SFA.DAS.Support.Indexer.ApplicationServices.Settings;

namespace SFA.DAS.Support.Indexer.Worker
{
    public interface IWebConfiguration
    {
        IndexerSiteSettings Site { get; set; }
        ElasticSearchSettings ElasticSearch { get; set; }
    }
}