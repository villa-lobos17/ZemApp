using System.Collections.Generic;
using ZemApp.Domain.Entities;
using ZemApp.Domain.Entities.BlogEnums;

namespace ZemApp.Domain.Services
{
    /// <summary>
    /// IBlogPostAppService interface
    /// </summary>
    public interface IBlogPostAppService
    {
        /// <summary>
        /// Gets the pending blog post.
        /// </summary>
        /// <returns></returns>
        List<Blog_PostDTO> GetPendingBlogPost();

        /// <summary>
        /// Updates the state of the post.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        void UpdatePostState(string id, string value);

        /// <summary>
        /// Gets the Active blog post.
        /// </summary>
        /// <returns></returns>
        List<Blog_PostDTO> GetActiveBlogPost();

        /// <summary>
        /// Gets the  blog post by state.
        /// </summary>
        /// <returns></returns>
        List<Blog_PostDTO> GetPendingBlogPostbyState(StatusEnum state);

        /// <summary>
        /// Updates the content of the post .
        /// </summary>
        /// <returns></returns>
        void UpdatePostContent(string id, string value);

        /// <summary>
        /// Delete post .
        /// </summary>
        /// <returns></returns>
        void DeletePost(string id);
        /// <summary>
        /// Add  post.
        /// </summary>
        /// <param name="post">The post.</param>
        void AddPost(AddPostDto pot);
    }
}