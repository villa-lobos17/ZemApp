using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;
using ZemApp.Domain.Entities;
using ZemApp.Domain.Repository;

namespace ZemApp.Infrastructure.MongoRepository.Repositories
{
    /// <summary>
    /// User repository class
    /// </summary>
    /// <seealso cref="ZemApp.Infrastructure.MongoRepository.Repositories.BaseRepository{ZemApp.Domain.Entities.User}" />
    /// <seealso cref="ZemApp.Domain.Repository.IUserRepository" />
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public UserRepository(IConfiguration config) : base(config, "User")
        {
        }

        /// <summary>
        /// Gets the user by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<User> GetUserByIdAsync(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the user by UserName asynchronous.
        /// </summary>
        /// <param name="Username">The identifier.</param>
        /// <returns></returns>
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(s => s.Username, username);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the user by credentials.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="pass">The pass.</param>
        /// <returns></returns>
        public async Task<User> GetUserByCredentials(string user, string pass)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Where(s => s.Username == user && s.Password == pass);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public async void CreateUser(User user)
        {
            await InsertAsync(user);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public async void UpdateUser(User user)
        {
            await UpdateAsync(user);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        public async void DeleteUser(string userId)
        {
            await DeleteAsync(userId);
        }
    }
}