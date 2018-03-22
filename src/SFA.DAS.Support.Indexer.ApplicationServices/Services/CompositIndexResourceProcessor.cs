using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using SFA.DAS.Support.Shared.Discovery;

namespace SFA.DAS.Support.Indexer.ApplicationServices.Services
{
    [ExcludeFromCodeCoverage]
    public class CompositIndexResourceProcessor : IIndexResourceProcessor
    {
        private readonly IIndexResourceProcessor[] _indexResourceProcessors;

        public CompositIndexResourceProcessor(IIndexResourceProcessor[] indexResourceProcessors)
        {
            _indexResourceProcessors =
                indexResourceProcessors ?? throw new ArgumentNullException($"IndexResourceProcessors");
        }

        public async Task ProcessResource(Uri basUri, SiteResource siteResource)
        {
            foreach (var indexResourceProcessor in _indexResourceProcessors)
                await indexResourceProcessor.ProcessResource(basUri, siteResource);
        }
    }
}