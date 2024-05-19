// ConoverHomeInspections
// ProductGroup.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using System.Text.Json.Serialization;

namespace ConoverHomeInspections.Shared
{
    public class SiteGroup
    {
        public SiteGroup()
        {
            Services = new HashSet<SiteService>();
        }

        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? Description { get; set; }
        public int Order { get; set; }
        public virtual ICollection<SiteService> Services { get; set; }
    }

}