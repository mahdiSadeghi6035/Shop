using _01_ShopQuery.Contract.GroupingProduct;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupingController : ControllerBase
    {
        private readonly IGroupingQuery _groupingQuery;

        public GroupingController(IGroupingQuery groupingQuery)
        {
            _groupingQuery = groupingQuery;
        }
        [HttpGet] 
        public IEnumerable<GroupingModel> GetLatestProduct()
        {
            return _groupingQuery.GetLatestProduct();
        }
        [HttpGet("Menu")]
        public IEnumerable<GroupingModel> GroupingWithCategoryProduct()
        {
            return _groupingQuery.GetGroupingWithCategoryProduct();
        }
    }
}
