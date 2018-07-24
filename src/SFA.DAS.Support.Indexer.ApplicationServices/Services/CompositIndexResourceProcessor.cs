using System;
using System.Threading.Tasks;
using SFA.DAS.Support.Shared.Discovery;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Indexer.ApplicationServices.Services
{
    public class CompositIndexResourceProcessor : IIndexResourceProcessor
    {
        private readonly IIndexResourceProcessor[] _indexResourceProcessors;

        public CompositIndexResourceProcessor(IIndexResourceProcessor[] indexResourceProcessors)
        {
            _indexResourceProcessors =
                indexResourceProcessors ?? throw new ArgumentNullException("IndexResourceProcessors");
        }

        public async Task ProcessResource(Uri basUri, SearchCategory searchCategory, string searchTotalItemsUrl, string searchItemsUrl)
        {
            foreach (var indexResourceProcessor in _indexResourceProcessors)
                await indexResourceProcessor.ProcessResource(basUri,searchCategory, searchTotalItemsUrl, searchItemsUrl);
        }
    }
}