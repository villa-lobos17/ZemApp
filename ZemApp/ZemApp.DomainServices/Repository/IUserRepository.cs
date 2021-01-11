using System.Threading.Tasks;
using ZemApp.Domain.Entities;

namespace ZemApp.Domain.Repository
{
    /// <summary>
    /// IUserRepository Interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void CreateUser(User user);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        void UpdateUser(User user);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        void DeleteUser(string userId);

        /// <summary>
        /// Gets the user by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<User> GetUserByIdAsync(string id);

        /// <summary>
        /// Gets the user by credentials.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="pass">The pass.</param>
        /// <returns></returns>
        Task<User> GetUserByCredentials(string user, string pass);

        /// <summary>
        /// Gets the user by UserName asynchronous.
        /// </summary>
        /// <param name="Username">The identifier.</param>
        /// <returns></returns>
        Task<User> GetUserByUsernameAsync(string username);
    }
}