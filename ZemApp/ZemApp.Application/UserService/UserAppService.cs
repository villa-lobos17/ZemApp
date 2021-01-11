using ZemApp.Domain.Repository;
using ZemApp.Domain.Services;

namespace ZemApp.Application.UserService
{
    /// <summary>
    /// User service
    /// </summary>
    /// <seealso cref="ZemApp.Domain.Services.IUserAppService" />
    public class UserAppService : IUserAppService
    {
        /// <summary>
        /// The user repository
        /// </summary>
        public readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAppService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public bool ValidateUser(string username)
        {
            Domain.Entities.User user = _userRepository.GetUserByUsernameAsync(username).Result;
            return user != null ? user.Active : false;
        }

        /// <summary>
        /// Validates the user by credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns></returns>
        public Domain.Entities.User ValidateUserByCredentials(string username, string passWord)
        {
            Domain.Entities.User user = _userRepository.GetUserByCredentials(username, passWord).Result;
            return user ?? null;
        }

        public Domain.Entities.User GetUserById(string id)
        {
            Domain.Entities.User user = _userRepository.GetUserByIdAsync(id).Result;
            return user ?? null;
        }
    }
}