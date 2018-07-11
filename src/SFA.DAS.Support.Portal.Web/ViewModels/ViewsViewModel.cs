using System.Diagnostics.CodeAnalysis;
using System.Web;

namespace SFA.DAS.Support.Portal.Web.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class ViewsViewModel
    {
        public HtmlString Content { get; set; } = new HtmlString(string.Empty);
    }
}