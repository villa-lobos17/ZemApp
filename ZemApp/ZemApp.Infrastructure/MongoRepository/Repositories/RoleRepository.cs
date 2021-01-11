using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;
using ZemApp.Domain.Entities;
using ZemApp.Domain.Repository;

namespace ZemApp.Infrastructure.MongoRepository.Repositories
{
    /// <summary>
    /// Role Repository Object
    /// </summary>
    /// <seealso cref="ZemApp.Infrastructure.MongoRepository.Repositories.BaseRepository{ZemApp.Domain.Entities.Role}" />
    /// <seealso cref="ZemApp.Domain.Repository.IRoleRepository" />
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public RoleRepository(IConfiguration config) : base(config, "Role")
        {
        }

        /// <summary>
        /// Gets the role by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Role> GetRoleByIdAsync(string id)
        {
            FilterDefinition<Role> filter = Builders<Role>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        public async void CreateRole(Role role)
        {
            await InsertAsync(role);
        }

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        public async void UpdateRole(Role role)
        {
            await UpdateAsync(role);
        }

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        public async void DeleteRole(string roleId)
        {
            await DeleteAsync(roleId);
        }
    }
}