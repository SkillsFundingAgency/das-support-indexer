using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace SFA.DAS.Support.Shared.Navigation
{
    /// <summary>
    ///     Transforms Menu templates into usable navigable Uri's
    /// </summary>
    public class MenuTemplateTransformer
    {
        public List<MenuItem> TransformMenuTemplates(List<MenuItem> templateItems, Uri baseUrl,
            Dictionary<string, string> identifiers)
        {
            var templateCopies =
                JsonConvert.DeserializeObject<List<MenuItem>>(JsonConvert.SerializeObject(templateItems));
            var menuItems = templateCopies.Map(s => true, n => n.MenuItems).ToList();
            foreach (var menuItem in menuItems)
            foreach (var identifier in identifiers)
                menuItem.NavigateUrl =
                    new Uri(baseUrl, menuItem.NavigateUrl)
                        .OriginalString
                        .Replace($"{{{identifier.Key}}}", identifier.Value);
            foreach (var menuItem in menuItems.ToList().Where(x => x.NavigateUrl.Contains("{")))
                templateCopies.Remove(menuItem);
            return templateCopies;
        }
    }
}