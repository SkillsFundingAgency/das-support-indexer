using System.Collections.Generic;

namespace SFA.DAS.Support.Shared.Navigation
{
    public class MenuItem
    {
        public string Key { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string NavigateUrl { get; set; } = "/";
        public int Ordinal { get; set; }
        public string[] Roles { get; set; } = { };
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}