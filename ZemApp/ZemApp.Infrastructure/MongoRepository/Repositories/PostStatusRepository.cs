using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;
using ZemApp.Domain.Entities;
using ZemApp.Domain.Repository;

namespace ZemApp.Infrastructure.MongoRepository.Repositories
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="ZemApp.Infrastructure.MongoRepository.Repositories.BaseRepository{ZemApp.Domain.Entities.Post_Status}" />
    /// <seealso cref="ZemApp.Domain.Repository.IPostStatusRepository" />
    public class PostStatusRepository : BaseRepository<Post_Status>, IPostStatusRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostStatusRepository"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public PostStatusRepository(IConfiguration config) : base(config, "PostStatus")
        {
        }

        /// <summary>
        /// Gets the post status by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Post_Status> GetPostStatusByIdAsync(string id)
        {
            FilterDefinition<Post_Status> filter = Builders<Post_Status>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates the post status.
        /// </summary>
        /// <param name="post">The post.</param>
        public async void CreatePostStatus(Post_Status post)
        {
            await InsertAsync(post);
        }

        /// <summary>
        /// Updates the post status.
        /// </summary>
        /// <param name="post">The post.</param>
        public async void UpdatePostStatus(Post_Status post)
        {
            await UpdateAsync(post);
        }

        /// <summary>
        /// Deletes the post status.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        public async void DeletePostStatus(string postId)
        {
            await DeleteAsync(postId);
        }
    }
}