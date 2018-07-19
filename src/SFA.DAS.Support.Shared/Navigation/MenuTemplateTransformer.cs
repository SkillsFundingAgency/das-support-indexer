using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace SFA.DAS.Support.Shared.Navigation
{
    public class MenuTemplateTransformer : IMenuTemplateTransformer
    {
        private readonly Uri _supportPortalUri;

        public MenuTemplateTransformer(Uri supportPortalUri)
        {
            _supportPortalUri = supportPortalUri;
        }

        public List<MenuItem> TransformMenuTemplates(List<MenuItem> templateItems,
            Dictionary<string, string> identifiers)
        {
            var templateCopies =
                JsonConvert.DeserializeObject<List<MenuItem>>(JsonConvert.SerializeObject(templateItems));
            var menuItems = templateCopies.Map(s => true, n => n.MenuItems).ToList();
            foreach (var menuItem in menuItems)
            foreach (var identifier in identifiers)
                menuItem.NavigateUrl =
                    new Uri(_supportPortalUri, menuItem.NavigateUrl)
                        .OriginalString
                        .Replace($"{{{identifier.Key}}}", identifier.Value);
            foreach (var menuItem in menuItems.ToList().Where(x => x.NavigateUrl.Contains("{")))
                templateCopies.Remove(menuItem);
            return templateCopies;
        }
    }
}