using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.Support.Shared.Navigation
{
    public interface IMenuClient
    {
        Task<List<MenuRoot>> GetMenuForPerspective(SupportMenuPerspectives perspectives, Uri source);
    }
}