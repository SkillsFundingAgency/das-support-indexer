namespace SFA.DAS.Support.Shared.SiteConnection
{
    public interface ISiteSettings
    {
        /// <summary>
        ///     A comma separated list of site base Url's e.g.
        ///     https://localhost:44312,https://localhost:44313
        /// </summary>
        string BaseUrls { get; set; }
    }
}