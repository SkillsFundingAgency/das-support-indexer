using System.Web;

namespace SFA.DAS.Support.Shared.ViewModels
{
    public class HeaderViewModel
    {
        public HtmlString Content { get; set; } = new HtmlString(string.Empty);
    }
}
