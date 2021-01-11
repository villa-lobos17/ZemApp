using System.Threading.Tasks;
using ZemApp.Domain.Entities;

namespace ZemApp.Domain.Repository
{
    /// <summary>
    /// Role repository interface
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>
        /// Gets the role by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Role> GetRoleByIdAsync(string id);

        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        void CreateRole(Role role);

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        void UpdateRole(Role role);

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        void DeleteRole(string roleId);
    }
}