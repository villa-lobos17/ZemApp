using System.Threading.Tasks;
using ZemApp.Domain.Entities;

namespace ZemApp.Infrastructure.MongoRepository.Interfaces
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        /// <summary>
        /// Inserts object asynchronous.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        Task InsertAsync(T obj);

        /// <summary>
        /// Updates object asynchronous.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        Task UpdateAsync(T obj);

        /// <summary>
        /// Deletes object asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(string id);
    }
}