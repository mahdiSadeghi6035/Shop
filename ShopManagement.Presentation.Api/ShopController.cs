using _01_ShopQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IProductQuery _productQuery;

        public ShopController(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        [HttpGet]
        public IEnumerable<ProductModel> Product()
        {
            return _productQuery.GetProduct();
        }
        [HttpGet("search")]
        public IEnumerable<ProductModel> Search(string value)
        {
            return _productQuery.SearchProduct(value);
        }

    }
}
