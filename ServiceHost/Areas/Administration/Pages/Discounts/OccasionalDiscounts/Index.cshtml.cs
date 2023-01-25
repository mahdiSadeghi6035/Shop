using DiscountManagement.Application.Contract.OccasionalDiscountsApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Discounts.OccasionalDiscounts
{
    public class IndexModel : PageModel
    {
        private readonly IOccasionalDiscountsApplication _occasionalDiscountsApplication;
        public SearchModelOccasionalDiscounts SearchModel { get; set; }
        public List<ViewModelOccasionalDiscounts> OccasionalDiscounts{ get; set; }
        public IndexModel(IOccasionalDiscountsApplication occasionalDiscountsApplication)
        {
            _occasionalDiscountsApplication = occasionalDiscountsApplication;
        }

        public void OnGet(SearchModelOccasionalDiscounts searchModel)
        {
            OccasionalDiscounts = _occasionalDiscountsApplication.Search(searchModel);
        }
    }
}
