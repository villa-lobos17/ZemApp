using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZemApp.Domain.Entities;
using ZemApp.Domain.Entities.BlogEnums;
using ZemApp.Domain.Repository;

namespace ZemApp.Infrastructure.MongoRepository.Repositories
{
    /// <summary>
    /// This repository handle a post acctions
    /// </summary>
    /// <seealso cref="ZemApp.Infrastructure.MongoRepository.Repositories.BaseRepository{ZemApp.Domain.Entities.Blog_Post}" />
    /// <seealso cref="ZemApp.Domain.Repository.IPostRepository" />
    public class PostRepository : BaseRepository<Blog_Post>, IPostRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostRepository"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public PostRepository(IConfiguration config) : base(config, "Post")
        {
        }

        /// <summary>
        /// Gets the post by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Blog_Post> GetPostByIdAsync(string id)
        {
            FilterDefinition<Blog_Post> filter = Builders<Blog_Post>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the post by state asynchronous.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public async Task<List<Blog_Post>> GetPostByStateAsync(StatusEnum status)
        {
            FilterDefinition<Blog_Post> filter = Builders<Blog_Post>.Filter.Eq(s => s.State, status);
            return await Collection.Find(filter).ToListAsync<Blog_Post>();
        }

        /// <summary>
        /// Creates the post.
        /// </summary>
        /// <param name="post">The post.</param>
        public async void CreatePost(Blog_Post post)
        {
            await InsertAsync(post);
        }

        /// <summary>
        /// Updates the post.
        /// </summary>
        /// <param name="post">The post.</param>
        public async void UpdatePost(Blog_Post post)
        {
            await UpdateAsync(post);
        }

        /// <summary>
        /// Deletes the post.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        public async void DeletePost(string postId)
        {
            await DeleteAsync(postId);
        }
    }
}