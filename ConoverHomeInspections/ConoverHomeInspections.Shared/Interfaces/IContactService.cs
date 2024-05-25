// ConoverHomeInspections
// IContactService.cs
//  2024
// Oliver Conover
// Modified: 23-05-2024
namespace ConoverHomeInspections.Shared
{
    /// <summary>
    /// The <see cref="IContactService"/> interface defines a contract for services that
    /// process contact form information. It contains a single method,
    /// <see cref="ProcessContactFormAsync(ClientContactDTO)"/>,
    /// which takes a <see cref="ClientContactDTO"/> instance and returns a <see cref="Task"/>.
    /// </summary>
    /// <remarks>
    /// A service designed to control the flow of client contacting the business.
    /// </remarks>
    public interface IContactService
    {
        /// <summary>
        /// Processes a given contact form by performing necessary operations on the provided contact information.
        /// </summary>
        /// <param name="contactInfo">A <see cref="ClientContactDTO"/> instance containing the contact information needed for processing the form</param>
        /// <returns><see cref="Task"/></returns>
        public Task ProcessContactFormAsync(ClientContactDTO contactInfo);
    }
}