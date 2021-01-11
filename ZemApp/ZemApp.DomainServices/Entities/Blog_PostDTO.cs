using System;
using ZemApp.Domain.Entities.BlogEnums;

namespace ZemApp.Domain.Entities
{
    /// <summary>
    /// Post DTO
    /// </summary>
    public class Blog_PostDTO
    {
        /// <summary>
        /// Gets or sets the post identifier.
        /// </summary>
        /// <value>
        /// The post identifier.
        /// </value>
        public string PostId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

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
        /// Gets or sets the update date.
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        public DateTime Update_Date { get; set; }
    }
}