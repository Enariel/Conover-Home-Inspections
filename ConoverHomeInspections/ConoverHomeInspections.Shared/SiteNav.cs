// ConoverHomeInspections
// SiteNav.cs
//  2024
// Oliver Conover
// Modified: 25-05-2024
namespace ConoverHomeInspections.Shared
{
    /// <summary>
    /// Site navigation data.
    /// </summary>
    public class SiteNav
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Navigation { get => $"/{Title}"; }
    }
}