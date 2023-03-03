using _01_ShopQuery.Contract.Brand;
using _01_ShopQuery.Contract.Slide;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandQuery _brandQuery;

        public BrandController(IBrandQuery brandQuery)
        {
            _brandQuery = brandQuery;
        }
        [HttpGet]
        public IEnumerable<BrandModel> GetBrands()
        {
            return _brandQuery.GetBrands();
        }
    }
}
