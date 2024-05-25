// ConoverHomeInspections
// ConfigurationSetting.cs
//  2024
// Oliver Conover
// Modified: 25-05-2024
namespace ConoverHomeInspections.Shared
{
    public class ConfigurationSetting
    {
        public int SettingId { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? For { get; set; }
        public int? Field { get; set; }
    }
}