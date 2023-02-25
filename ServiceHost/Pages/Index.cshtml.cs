using _01_ShopQuery.Contract.GroupingProduct;
using _01_ShopQuery.Contract.Slide;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGroupingQuery _groupingQuery;
        public IEnumerable<GroupingModel> Groupings{ get; set; }
        public IndexModel(IGroupingQuery groupingQuery)
        {
            _groupingQuery = groupingQuery;
        }

        public void OnGet()
        {
           Groupings = _groupingQuery.GetLatestProduct();
        }
    }
}
