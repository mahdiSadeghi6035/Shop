using _01_ShopQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery _productQuery;

        public ProductController(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        [HttpGet]
        public IEnumerable<ProductModel> Product()
        {
            return _productQuery.GetProduct();
        }
        [HttpGet("{value}")]
        public IEnumerable<ProductModel> Search(string value)
        {
            return _productQuery.SearchProduct(value);
        }
        
        
    }
}
