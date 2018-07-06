using System;
using System.Threading.Tasks;
using SFA.DAS.Support.Shared.Discovery;

namespace SFA.DAS.Support.Indexer.ApplicationServices.Services
{
    public interface IIndexResourceProcessor
    {
        Task ProcessResource(Uri basUri, SiteResource siteResource);
    }
}