using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    /// <summary>
    /// The products controller.
    /// </summary>
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }
        /// <summary>
        /// Indices the.
        /// </summary>
        /// <returns>An IActionResult.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
    }
}
