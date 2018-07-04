using System.Collections.Generic;

namespace SFA.DAS.Support.Shared.Navigation
{
    public interface IMenuClient
    {
        IEnumerable<MenuRoot> GetMenuForPerspective(SupportMenuPerspectives perspective);
    }

    public class MenuClient : IMenuClient
    {
        public IEnumerable<MenuRoot> GetMenuForPerspective(SupportMenuPerspectives perspective)
        {
            throw new System.NotImplementedException();
        }
    }
}