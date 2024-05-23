// ConoverHomeInspections
// AddressDTO.cs
//  2024
// Oliver Conover
// Modified: 22-05-2024
using System.ComponentModel.DataAnnotations;

namespace ConoverHomeInspections.Shared
{
    public class AddressDTO
    {
        [MaxLength(255)]
        public string Street { get; set; }
        [MaxLength(255)]
        public string Street2 { get; set; }
        [MaxLength(255)]
        public string City { get; set; }
        public string State { get; set; }
        public int? ZipCode { get; set; }
    }
}