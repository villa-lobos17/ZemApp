using System;
using ZemApp.Domain.Entities.BlogEnums;

namespace ZemApp.Domain.Entities
{
    /// <summary>
    /// Post entity
    /// </summary>
    /// <seealso cref="ZemApp.Domain.Entities.BaseEntity" />
    public class Blog_Post : BaseEntity
    {
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public User Author { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the post.
        /// </summary>
        /// <value>
        /// The content of the post.
        /// </value>
        public string Post_Content { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public StatusEnum State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Blog_Post"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime Creation_Date { get; set; }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        public DateTime Update_Date { get; set; }
    }

    public class UpdateState
    {
        public string State { get; set; }
    }
}