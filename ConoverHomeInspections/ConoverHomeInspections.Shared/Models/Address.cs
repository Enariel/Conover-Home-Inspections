// ConoverHomeInspections
// Address.cs
//  2024
// Oliver Conover
// Modified: 15-05-2024
namespace ConoverHomeInspections.Shared
{
    public class Address
    {
        public required string Street { get; set; }
        public string? Street2 { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public int ZipCode { get; set; }
        public int? Zip4 { get; set; }
    }
}