using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZemApp.Domain.Entities;
using ZemApp.Infrastructure.MongoRepository.Interfaces;

namespace ZemApp.Infrastructure.MongoRepository.Repositories
{
    /// <summary>
    /// Base reopository class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ZemApp.Infrastructure.MongoRepository.Interfaces.IRepositoryBase{T}" />
    public class BaseRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
        /// <summary>
        /// The database
        /// </summary>
        private const string DATABASE = "ZemApp";

        /// <summary>
        /// The mongo client
        /// </summary>
        private readonly IMongoClient _mongoClient;

        /// <summary>
        /// The collection
        /// </summary>
        private readonly string _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="collection">The collection.</param>
        public BaseRepository(IConfiguration config, string collection)
        {
            _mongoClient = new MongoClient(config.GetSection("MongoConnection:ConnectionString").Value);
            _collection = collection;

            if (!_mongoClient.GetDatabase(DATABASE).ListCollectionNames().ToList().Contains(collection))
                _mongoClient.GetDatabase(DATABASE).CreateCollection(collection);
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>
        /// The collection.
        /// </value>
        protected virtual IMongoCollection<T> Collection =>
            _mongoClient.GetDatabase(DATABASE).GetCollection<T>(_collection);

        /// <summary>
        /// Inserts object asynchronous.
        /// </summary>
        /// <param name="obj">The object.</param>
        public async Task InsertAsync(T obj) =>
            await Collection.InsertOneAsync(obj);

        /// <summary>
        /// Updates object asynchronous.
        /// </summary>
        /// <param name="obj">The object.</param>
        public async Task UpdateAsync(T obj)
        {
            Expression<Func<T, string>> func = f => f.Id;
            var value = (string)obj.GetType().GetProperty(func.Body.ToString().Split(".")[1]).GetValue(obj, null);
            var filter = Builders<T>.Filter.Eq(func, value);

            if (obj != null)
                await Collection.ReplaceOneAsync(filter, obj);
        }

        /// <summary>
        /// Deletes object asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task DeleteAsync(string id) =>
            await Collection.DeleteOneAsync(f => f.Id == id);
    }
}