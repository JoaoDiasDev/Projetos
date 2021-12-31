using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    /// <summary>
    /// The category.
    /// </summary>
    public sealed class Category : Entity
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Category(string name)
        {
            ValidateDomain(name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }

        /// <summary>
        /// Updates the.
        /// </summary>
        /// <param name="name">The name.</param>
        public void Update(string name)
        {
            ValidateDomain(name);
        }
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public ICollection<Product> Products { get; set; }

        /// <summary>
        /// Validates the domain.
        /// </summary>
        /// <param name="name">The name.</param>
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}
