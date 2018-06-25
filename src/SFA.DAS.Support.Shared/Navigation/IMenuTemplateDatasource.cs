using System.Collections.Generic;

namespace SFA.DAS.Support.Shared.Navigation
{
    public interface IMenuTemplateDatasource
    {
        List<MenuRoot> Provide();
    }
}