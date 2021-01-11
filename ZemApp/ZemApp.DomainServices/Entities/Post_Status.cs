namespace ZemApp.Domain.Entities
{
    /// <summary>
    /// Post status entity for Post object
    /// </summary>
    /// <seealso cref="ZemApp.Domain.Entities.BaseEntity" />
    public class Post_Status : BaseEntity
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Post_Status"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }
    }
}