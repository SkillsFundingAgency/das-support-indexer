using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Support.Shared.Navigation
{
    /// <summary>
    /// Provides transformed menu tempaltes as navigable Uri's to the UI rendering layer.
    /// </summary>
    public class MenuViewModel
    {
        /// <summary>
        /// Determines the intended rendering orientation for this menu
        /// </summary>
        public MenuOrientations MenuOrientation { get; set; }
        /// <summary>
        ///     Provides raw presentation and navigational data for a Menu
        /// </summary>
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        /// <summary>
        /// Lists the progression of Menu item selections down the entire menu tree. "Account", "Account.Finance", "Account.Finance.PAYE"
        /// <remarks>Requires the key convention to be dot delimited graph address e.g. Item.SubItem1.Subitem2</remarks>
        /// </summary>
        public List<string> SelectedMenuItemKeys { get; private set; } = new List<string>();
        /// <summary>
        /// Sets teh menu from the supplied items and using the selected current menu item
        /// </summary>
        /// <param name="items">The menu item templates to use</param>
        /// <param name="selectedMenuItem"></param>
        public void SetMenu(List<MenuItem> items, string selectedMenuItem)
        {
            var elements = selectedMenuItem.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var keys = elements.Select((t, i) => 
                    (string) elements.Take(i + 1).Aggregate(string.Empty, (current, keyElement) => $"{current}{(string.IsNullOrWhiteSpace(current) ? "" : ".")}{keyElement}"))
                .ToList();
            SelectedMenuItemKeys = keys;
            MenuItems = items.Where(x => x.Key.StartsWith(SelectedMenuItemKeys.FirstOrDefault()?? x.Key)).ToList();
        }
    }
}