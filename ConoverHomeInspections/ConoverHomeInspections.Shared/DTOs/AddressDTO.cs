// ConoverHomeInspections
// AddressDTO.cs
//  2024
// Oliver Conover
// Modified: 22-05-2024
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConoverHomeInspections.Shared
{
    public class AddressDTO
    {
        /// <summary>
        /// Represents a street address.
        /// </summary>
        [MaxLength(255)]
        public string Street { get; set; }
        /// <summary>
        /// Gets or sets the extended street address for the <see cref="AddressDTO"/>.
        /// </summary>
        /// <remarks>
        /// This property provides an optional field to store additional information about the street address,
        /// such as apartment number, unit number, or building name.
        /// </remarks>
        /// <value>
        /// The extended street address for the <see cref="AddressDTO"/>.
        /// </value>
        [MaxLength(255)]
        public string Street2 { get; set; }
        /// <summary>
        /// Represents the city of an address.
        /// </summary>
        [MaxLength(255)]
        public string City { get; set; }
        /// <summary>
        /// Class representing the state of an address.
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the zip code of the address.
        /// </summary>
        public int? ZipCode { get; set; }

        ///<summary>
        /// Returns a string representation of the object.
        /// </summary>
        /// <returns>A string representation of the object.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Street?.ToUpperInvariant()} {Street2?.ToUpperInvariant()}, ");
            sb.AppendLine($"{City?.ToUpperInvariant()} {State?.ToUpperInvariant()}, ");
            sb.Append($"{ZipCode}");
            return sb.ToString();
        }
    }
}