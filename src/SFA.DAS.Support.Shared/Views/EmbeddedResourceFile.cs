using System.IO;
using System.Reflection;
using System.Web.Hosting;

namespace SFA.DAS.Support.Shared.Views
{
    public class EmbeddedResourceFile : VirtualFile
    {
        public EmbeddedResourceFile(string virtualPath) : base(virtualPath)
        {
        }

        public static string GetResourceName(string virtualPath)
        {
            if (!virtualPath.Contains("/Views/")) return null;

            var resourcename =
                virtualPath
                    .Substring(virtualPath.IndexOf("Views/"))
                    // NB: Your assembly name here
                    .Replace("Views/", "SFA.DAS.Support.Shared.Views.")
                    .Replace("/", ".");

            return resourcename;
        }

        public override Stream Open()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcename = GetResourceName(VirtualPath);
            // ReSharper disable once AssignNullToNotNullAttribute
            return assembly.GetManifestResourceStream(resourcename);
        }
    }
}