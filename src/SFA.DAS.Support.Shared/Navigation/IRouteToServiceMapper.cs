using SFA.DAS.Support.Shared.Discovery;

namespace SFA.DAS.Support.Shared.Navigation
{
    public interface IRouteToServiceMapper
    {
        SupportServiceIdentity Service(string path);
    }
}