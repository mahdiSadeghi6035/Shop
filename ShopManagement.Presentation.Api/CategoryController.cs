using _01_ShopQuery.Contract.Category;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryQuery _categoryQuery;

        public CategoryController(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }
        [HttpGet]
        public IEnumerable<CategoryModel> GetCategory()
        {
            return _categoryQuery.GetCategory();
        }
    }
}
