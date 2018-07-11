using System;
using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Support.Shared.Discovery;
using SFA.DAS.Support.Shared.SiteConnection;

namespace SFA.DAS.Support.Shared.Navigation
{
    public class ServiceAddressMapper : IServiceAddressMapper
    {
        private ISiteSettings _settings;
        private readonly Dictionary<SupportServiceIdentity, Uri> _serviceAddresses = new Dictionary<SupportServiceIdentity, Uri>();

        public ServiceAddressMapper(ISiteSettings settings)
        {
            _settings = settings;
        }

        public Uri Addressof(SupportServiceIdentity service)
        {
            if (!_serviceAddresses.Any())
            {
                GetAddresses();
            }
            return _serviceAddresses[service];
        }

        private void GetAddresses()
        {
            var settings = _settings.BaseUrls.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries);
            if (settings.Length < 1) return;
            foreach (var setting in settings)
            {
                var elements = setting.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length != 2) continue;
                var service = (SupportServiceIdentity)Enum.Parse( typeof(SupportServiceIdentity), elements.First());
                _serviceAddresses.Add(service, new Uri(elements.Skip(1).First(), UriKind.RelativeOrAbsolute));
            }
        }
    }
}