using System.Threading.Tasks;
using ZemApp.Domain.Entities;

namespace ZemApp.Domain.Repository
{
    /// <summary>
    /// PostStatusRepository interface
    /// </summary>
    public interface IPostStatusRepository
    {
        /// <summary>
        /// Gets the post status by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Post_Status> GetPostStatusByIdAsync(string id);

        /// <summary>
        /// Creates the post status.
        /// </summary>
        /// <param name="post">The post.</param>
        void CreatePostStatus(Post_Status post);

        /// <summary>
        /// Updates the post status.
        /// </summary>
        /// <param name="post">The post.</param>
        void UpdatePostStatus(Post_Status post);

        /// <summary>
        /// Deletes the post status.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        void DeletePostStatus(string postId);
    }
}