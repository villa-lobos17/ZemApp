namespace ZemApp.Domain.Services
{
    /// <summary>
    /// User service
    /// </summary>
    public interface IUserAppService
    {
        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        bool ValidateUser(string username);

        /// <summary>
        /// Validates the user by credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="passWord">The pass word.</param>
        /// <returns></returns>
        Domain.Entities.User ValidateUserByCredentials(string username, string passWord);

        Domain.Entities.User GetUserById(string id);
    }
}