using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    /// <summary>
    /// The product.
    /// </summary>
    public sealed class Product : Entity
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Gets the price.
        /// </summary>
        public decimal Price { get; private set; }
        /// <summary>
        /// Gets the stock.
        /// </summary>
        public int Stock { get; private set; }
        /// <summary>
        /// Gets the image.
        /// </summary>
        public string Image { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="stock">The stock.</param>
        /// <param name="image">The image.</param>
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="stock">The stock.</param>
        /// <param name="image">The image.</param>
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        /// <summary>
        /// Updates the.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="stock">The stock.</param>
        /// <param name="image">The image.</param>
        /// <param name="categoryId">The category id.</param>
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        /// <summary>
        /// Validates the domain.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="stock">The stock.</param>
        /// <param name="image">The image.</param>
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image name, too long, maximum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

        }

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public Category Category { get; set; }
    }
}
