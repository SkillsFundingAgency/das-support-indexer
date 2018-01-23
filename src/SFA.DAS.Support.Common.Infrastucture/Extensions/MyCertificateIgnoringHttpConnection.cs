﻿using System.Net;
using Elasticsearch.Net;

namespace SFA.DAS.Support.Common.Infrastucture.Extensions
{
    public class MyCertificateIgnoringHttpConnection : HttpConnection
    {
        protected override HttpWebRequest CreateHttpWebRequest(RequestData requestData)
        {
            var httpWebRequest = base.CreateHttpWebRequest(requestData);
            httpWebRequest.ServerCertificateValidationCallback =
                (sender, certificate, chain, errors) => true;
            return httpWebRequest;
        }
    }
}