using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.Support.Shared.Navigation
{
    public interface IMenuService
    {
        Task<List<MenuRoot>> GetMenu(SupportMenuPerspectives employerAccount);
    }
}