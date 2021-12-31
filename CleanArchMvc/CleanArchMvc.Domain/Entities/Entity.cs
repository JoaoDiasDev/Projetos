namespace CleanArchMvc.Domain.Entities
{
    /// <summary>
    /// The entity.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; protected set; }
    }
}
