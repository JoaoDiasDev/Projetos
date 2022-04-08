namespace CleanArchMvc.Application.Products.Commands
{
    /// <summary>
    /// The product update command.
    /// </summary>
    public class ProductUpdateCommand : ProductCommand
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}
