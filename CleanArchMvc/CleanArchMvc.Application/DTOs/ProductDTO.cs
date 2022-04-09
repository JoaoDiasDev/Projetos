using CleanArchMvc.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CleanArchMvc.Application.DTOs
{
    /// <summary>
    /// The product d t o.
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        [Required(ErrorMessage = "The Stock is Required")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        [JsonIgnore]
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        [DisplayName("Categories")]
        public int CategoryId { get; set; }
    }
}
