using System.Collections.Generic;

namespace SFA.DAS.Support.Shared.Navigation
{
    public class MenuRoot
    {
        public SupportMenuPerspectives Perspective { get; set; }
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}