using System;
using System.Collections.Generic;
using ZemApp.Domain.Entities;
using ZemApp.Domain.Entities.BlogEnums;
using ZemApp.Domain.Repository;
using ZemApp.Domain.Services;

namespace ZemApp.Application.PostService
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="ZemApp.Domain.Services.IBlogPostAppService" />
    public class BlogPostAppService : IBlogPostAppService
    {
        /// <summary>
        /// The post repository
        /// </summary>
        public readonly IPostRepository _postRepository;

        /// <summary>
        /// The post repository
        /// </summary>
        public readonly IUserRepository _userRepository;

        /// <summary>
        /// The role repository
        /// </summary>
        public readonly IRoleRepository _roleRepository;

        /// <summary>
        /// The post status repository
        /// </summary>
        public readonly IPostStatusRepository _postStatusRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostAppService" /> class.
        /// </summary>
        /// <param name="postRepository">The post repository.</param>
        /// <param name="roleRepository">The role repository.</param>
        /// <param name="postStatusRepository">The post status repository.</param>
        public BlogPostAppService(IPostRepository postRepository,
                                  IRoleRepository roleRepository,
                                  IUserRepository userRepository,
                                  IPostStatusRepository postStatusRepository)
        {
            _postRepository = postRepository;
            _roleRepository = roleRepository;
            _postStatusRepository = postStatusRepository;
            _userRepository = userRepository;
        }

        #region public methods

        /// <summary>
        /// Gets the Active blog post.
        /// </summary>
        /// <returns></returns>
        public List<Blog_PostDTO> GetActiveBlogPost()
        {
            return GetPendingBlogPostbyState(StatusEnum.Approve);
        }

        /// <summary>
        /// Gets the pending blog post.
        /// </summary>
        /// <returns></returns>
        public List<Blog_PostDTO> GetPendingBlogPost()
        {
            return GetPendingBlogPostbyState(StatusEnum.Pending);
        }

        /// <summary>
        /// Gets the  blog post by state.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<Blog_PostDTO> GetPendingBlogPostbyState(StatusEnum state)
        {
            List<Blog_Post> pendingPost = _postRepository.GetPostByStateAsync(state).Result;
            List<Blog_PostDTO> pendingPostResult = new List<Blog_PostDTO>();
            Blog_PostDTO blog_Post;
            foreach (Blog_Post item in pendingPost)
            {
                blog_Post = new Blog_PostDTO
                {
                    PostId = item.Id,
                    Post_Content = item.Post_Content,
                    State = item.State,
                    Title = item.Title,
                    Update_Date = item.Update_Date,
                    UserName = $"{item.Author.FirstName} {item.Author.LastName}"
                };
                pendingPostResult.Add(blog_Post);
            }
            return pendingPostResult;
        }

        /// <summary>
        /// Updates the state of the post.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        public void UpdatePostState(string id, string value)
        {
            Blog_Post post = _postRepository.GetPostByIdAsync(id).Result;
            post.State = (StatusEnum)Enum.Parse(typeof(StatusEnum), value);
            _postRepository.UpdatePost(post);
        }

        /// <summary>
        /// Updates the content of the post .
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void UpdatePostContent(string id, string value)
        {
            Blog_Post post = _postRepository.GetPostByIdAsync(id).Result;
            post.Post_Content = value;
            _postRepository.UpdatePost(post);
        }

        /// <summary>
        /// Delete post .
        /// </summary>
        /// <param name="id"></param>
        public void DeletePost(string id)
        {
            _postRepository.DeletePost(id);
        }

        /// <summary>
        /// Add post.
        /// </summary>
        /// <param name="post">The post.</param>
        public void AddPost(AddPostDto pot)
        {
            var user = _userRepository.GetUserByIdAsync(pot.AuthorId).Result;
            Blog_Post post = new Blog_Post
            {
                Active = true,
                State = StatusEnum.Pending,
                Author = user,
                Creation_Date = DateTime.Now,
                Title = pot.Title,
                Update_Date = DateTime.Now,
                Post_Content = pot.Post_Content
            };
            _postRepository.CreatePost(post);
        }

        #endregion public methods
    }
}