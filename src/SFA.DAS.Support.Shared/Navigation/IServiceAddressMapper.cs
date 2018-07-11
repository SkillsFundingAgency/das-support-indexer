using System;
using SFA.DAS.Support.Shared.Discovery;

namespace SFA.DAS.Support.Shared.Navigation
{
    public interface IServiceAddressMapper
    {
        Uri Addressof(SupportServiceIdentity service);
    }
}