using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace ZemApp.Domain.Entities
{
    /// <summary>
    /// Base entity object
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public virtual string Id { get; private set; }

        /// <summary>
        /// Sets the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void SetId(string id) =>
            Id = id;
    }
}