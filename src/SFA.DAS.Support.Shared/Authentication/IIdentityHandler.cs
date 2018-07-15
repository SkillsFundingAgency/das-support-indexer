using System;
using System.IdentityModel.Protocols.WSTrust;
using System.Net.Http;
using System.Web;

namespace SFA.DAS.Support.Shared.Authentication
{
    public interface IIdentityHandler
    {
        string GetIdentity(HttpRequestBase request);

        void SetIdentity(HttpRequestBase request, string identity);

    }
}