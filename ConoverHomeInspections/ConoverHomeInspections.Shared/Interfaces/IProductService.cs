// ConoverHomeInspections
// IProductService.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
namespace ConoverHomeInspections.Shared
{
    /// <summary>
    /// Interface for the product service.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Get all groups.
        /// </summary>
        /// <returns> <see cref="Task{T}" /> with a <see cref="List{T}" /> of <see cref="ServiceGroupDTO" />. </returns>
        public Task<List<ServiceGroupDTO>> GetGroupsAsync();

        /// <summary>
        /// Get all services.
        /// </summary>
        /// <returns> <see cref="Task{T}" /> of <see cref="List{T}" /> of <see cref="ServiceDTO" />. </returns>
        public Task<List<ServiceDTO>> GetServicesAsync();

        /// <summary>
        /// Get all services in a group.
        /// </summary>
        /// <param name="groupId"> The id of the group to get services for. </param>
        /// <returns> <see cref="Task{T}" /> of <see cref="List{T}" /> of <see cref="ServiceDTO" />. </returns>
        public Task<List<ServiceDTO>> GetGroupServicesAsync(int groupId);

        /// <summary>
        /// Get a service by its id.
        /// </summary>
        /// <param name="serviceId"> The id of the service to get. </param>
        /// <returns> <see cref="Task{T}" /> of <see cref="ServiceDTO" />. </returns>
        public Task<ServiceDTO> GetServiceById(int serviceId);
    }
}