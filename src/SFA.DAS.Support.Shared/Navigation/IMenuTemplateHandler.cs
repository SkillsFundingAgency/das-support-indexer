using System.Collections.Generic;

namespace SFA.DAS.Support.Shared.Navigation
{
    public interface IMenuTemplateHandler
    {
        IEnumerable<MenuRoot> GetMenuForPerspective(SupportMenuPerspectives perspective);
    }
}