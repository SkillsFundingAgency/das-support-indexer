﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Portal.ApplicationServices.Models;
using SFA.DAS.Support.Portal.ApplicationServices.Settings;
using SFA.DAS.Support.Shared;
using NavItem = SFA.DAS.Support.Portal.ApplicationServices.Models.NavItem;

namespace SFA.DAS.Support.Portal.ApplicationServices.Services
{
    public class ManifestRepository : IManifestRepository
    {
        private readonly ISiteConnector _downloader;
        private readonly IFormMapper _formMapper;
        private readonly ILog _log;
        private readonly ISiteSettings _settings;
        private List<SiteManifest> _manifests = new List<SiteManifest>();
        private IDictionary<string, SiteResource> _resources = new Dictionary<string, SiteResource>();
        private IDictionary<string, SiteChallenge> _challenges = new Dictionary<string, SiteChallenge>();
        private List<SearchResultMetadata> _searchResultsMetadata;

        public ManifestRepository(ISiteSettings settings, ISiteConnector downloader, IFormMapper formMapper, ILog log)
        {
            _downloader = downloader;
            _formMapper = formMapper;
            _log = log;
            _settings = settings;
        }

        private async Task PollSites()
        {
            if (_manifests.Any()) return;
            _manifests = await LoadManifest();
            _resources = new Dictionary<string, SiteResource>();
            _challenges = new Dictionary<string, SiteChallenge>();
            _searchResultsMetadata = new List<SearchResultMetadata>();

            foreach (var siteManifest in _manifests)
            {
                foreach (var item in siteManifest.Resources ?? new List<SiteResource>())
                {
                    _resources.Add(item.ResourceKey, item);
                }
                foreach (var item in siteManifest.Challenges?? new List<SiteChallenge>())
                {
                    _challenges.Add(item.ChallengeKey, item);
                }

                foreach (var metaData in siteManifest.SearchResultsMetadata ?? new List<SearchResultMetadata>())
                {
                    _searchResultsMetadata.Add(metaData);
                }
            }
        }

        private ICollection<SiteManifest> Manifests
        {
            get
            {
                return _manifests;
            }
        }
        
        private IDictionary<string, SiteResource> Resources
        {
            get { return _resources; }
        }

        private List<SearchResultMetadata> SearchResultsMetadata
        {
            get
            {
                return _searchResultsMetadata;
            }
        }

        private IDictionary<string, SiteChallenge> Challenges
        {
            get { return _challenges; }
        }

        public async Task<bool> ChallengeExists(string key)
        {
            return await Task.FromResult(Challenges.ContainsKey(FormatKey(key)));
        }

        public async Task<SiteChallenge> GetChallenge(string key)
        {
            await PollSites();
            var challenge = Challenges[FormatKey(key)];
            var site = Manifests.FirstOrDefault(x => x.Challenges.Select(y => FormatKey(y.ChallengeKey)).Contains(key.ToLower()));
            if (site == null || site.BaseUrl == null)
            {
                throw new NullReferenceException($"The challenge {FormatKey(key)} could not be found in any manifest");
            }

            challenge.ChallengeUrlFormat = new Uri(new Uri(site.BaseUrl), challenge.ChallengeUrlFormat).ToString();
            return await Task.FromResult(challenge);
        }

        public async Task<bool> ResourceExists(string key)
        {
            await PollSites();
            return await Task.FromResult(Resources.ContainsKey(FormatKey(key)));
        }

        public async Task<object> GenerateHeader(string key, string id)
        {
            var headerKey = key.ToLower().Split('/')[0] + "/header";
            if (!await ResourceExists(headerKey))
            {
                return "";
            }

            var resource = await GetResource(headerKey);
            var url = string.Format(resource.ResourceUrlFormat, id);
            return await GetPage(url);
        }

        public async Task<string> GetChallengeForm(string key, string id, string url)
        {
            var challenge = await GetChallenge(key);
            var challengeUrl = string.Format(challenge.ChallengeUrlFormat, id);
            var page = await GetPage(challengeUrl);
            return _formMapper.UpdateForm(key, id, url, page);
        }

        public async Task<ChallengeResult> SubmitChallenge(string id, IDictionary<string, string> formData)
        {
            var redirect = formData["redirect"];
            var innerAction = formData["innerAction"];
            var challengekey = "challengeKey";
            var key = formData[challengekey];

            if (!await ChallengeExists(key))
            {
                throw new MissingMemberException();
            }

            var site = FindSiteForChallenge(key);

            var uri = new Uri(site, innerAction);
            formData.Remove("redirect");
            formData.Remove("innerAction");
            formData.Remove(challengekey);

            var html = await _downloader.Upload<string>(uri, formData);

            if (string.IsNullOrWhiteSpace(html))
                return new ChallengeResult { RedirectUrl = redirect };

            return new ChallengeResult
            {
                Page = _formMapper.UpdateForm(key, id, redirect, html)
            };
        }

        public async Task<List<SiteManifest>> GetManifests()
        {
            try
            {
                var result = await Task.FromResult(_manifests);
                return result;
            }
            catch (Exception ex)
            {
                _log.Error(ex, nameof(GetManifests));
            }
            return await Task.FromResult(new List<SiteManifest>());
        }

        public async Task<List<SearchResultMetadata>> GetSearchResultsMetadata()
        {
            try
            {
                await PollSites();
                return _searchResultsMetadata;
            }
            catch (Exception ex)
            {
                _log.Error(ex, nameof(GetManifests));
            }

            return new List<SearchResultMetadata>();
        }

        private Uri FindSiteForChallenge(string key)
        {
            var site = _manifests.FirstOrDefault(x =>
                x.Challenges.Select(y => y.ChallengeKey.ToLower()).Contains(key.ToLower()));
            return new Uri(site?.BaseUrl);
        }

        public async Task<SiteResource> GetResource(string key)
        {
            await PollSites();
            var resource = Resources[FormatKey(key)];
            var site = Manifests.FirstOrDefault(x => x.Resources.Select(y => FormatKey(y.ResourceKey)).Contains(FormatKey(key)));
            if (site == null || site.BaseUrl == null)
            {
                throw new NullReferenceException($"The resource {FormatKey(key)} could not be found in any manifest");
            }
            resource.ResourceUrlFormat = new Uri(new Uri(site.BaseUrl), resource.ResourceUrlFormat).ToString();
            return await Task.FromResult(resource);
        }

        public async Task<NavViewModel> GetNav(string key, string id)
        {
            return await Task.FromResult(new NavViewModel
            {
                Current = key,
                Items = GetNavItems(key, id).ToArray()
            });
        }

        private IEnumerable<NavItem> GetNavItems(string key, string id)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (id == null) throw new ArgumentNullException(nameof(id));

            return Resources
                .Where(x => x.Key.StartsWith(key.Split('/').FirstOrDefault() ?? ""))
                .Where(x => !string.IsNullOrEmpty(x.Value.ResourceTitle))
                .Select(x =>
                    new NavItem
                    {
                        Title = x.Value.ResourceTitle,
                        Key = x.Key,
                        Href = $"/resource?key={x.Key}&id={id}"
                    });
        }

        public async Task<string> GetResourcePage(string key, string id)
        {
            var resource = await GetResource(key);
            var url = string.Format(resource.ResourceUrlFormat, id);
            return await GetPage(url);
        }

        private async Task<string> GetPage(string url)
        {
            try
            {
                var result = await _downloader.Download(AddQueryString(url));

                return result;
            }
            catch
            {
                return @"<h3 style='color:red'>There was a problem downloading this asset</h3>
<div style='display:none'>{url}</div>";
            }
        }

        private string AddQueryString(string url)
        {
            var uriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["parent"] = string.Empty;
            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }

        private string FormatKey(string key)
        {
            return key?.ToLower();
        }

        private async Task<List<SiteManifest>> LoadManifest()
        {

            var list = new Dictionary<string, SiteManifest>();
            foreach (var site in _settings.Sites.Where(x => !string.IsNullOrEmpty(x)))
            {
                _log.Debug($"Downloading '{site}'");
                var uri = new Uri(new Uri(site), "/api/manifest");

                try
                {
                    var manifest = await _downloader.Download<SiteManifest>(uri);
                    list.Add(uri.ToString(), manifest);

                }
                catch (Exception ex)
                {
                    _log.Error(ex, $"Exception occured calling {nameof(ISiteConnector)}.{nameof(ISiteConnector.Download)}<{nameof(SiteManifest)}>('{uri}'");
                }

            }
            return list.Values.ToList();
        }
    }
}