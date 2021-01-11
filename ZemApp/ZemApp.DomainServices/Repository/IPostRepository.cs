using System.Collections.Generic;
using System.Threading.Tasks;
using ZemApp.Domain.Entities;
using ZemApp.Domain.Entities.BlogEnums;

namespace ZemApp.Domain.Repository
{
    /// <summary>
    /// Post repository interface
    /// </summary>
    public interface IPostRepository
    {
        /// <summary>
        /// Gets the post by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Blog_Post> GetPostByIdAsync(string id);

        /// <summary>
        /// Gets the post by state asynchronous.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        Task<List<Blog_Post>> GetPostByStateAsync(StatusEnum status);

        /// <summary>
        /// Creates the post.
        /// </summary>
        /// <param name="post">The post.</param>
        void CreatePost(Blog_Post post);

        /// <summary>
        /// Updates the post.
        /// </summary>
        /// <param name="post">The post.</param>
        void UpdatePost(Blog_Post post);

        /// <summary>
        /// Deletes the post.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        void DeletePost(string postId);
    }
}