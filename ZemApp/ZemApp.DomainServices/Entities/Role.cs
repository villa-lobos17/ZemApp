namespace ZemApp.Domain.Entities
{
    /// <summary>
    /// Role Entity
    /// </summary>
    /// <seealso cref="ZemApp.Domain.Entities.BaseEntity" />
    public class Role : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the rol.
        /// </summary>
        /// <value>
        /// The name of the rol.
        /// </value>
        public string Rol_Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Role"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }
    }
}