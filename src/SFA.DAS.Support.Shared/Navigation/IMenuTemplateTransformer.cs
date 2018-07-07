using System;
using System.Collections.Generic;

namespace SFA.DAS.Support.Shared.Navigation
{
    public interface IMenuTemplateTransformer
    {
        /// <summary>
        ///     Transforms Menu templates into usable navigable Uri's
        /// </summary>
        List<MenuItem> TransformMenuTemplates(List<MenuItem> templateItems,
            Dictionary<string, string> identifiers);
    }
}