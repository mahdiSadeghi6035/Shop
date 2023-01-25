using DiscountManagement.Application.Contract.OccasionalDiscountsApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductApp;

namespace ServiceHost.Areas.Administration.Pages.Discounts.OccasionalDiscounts
{
    public class CreateModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IOccasionalDiscountsApplication _occasionalDiscountsApplication;
        public CreateOccasionalDiscounts Command { get; set; }
        public SelectList SelectLists{ get; set; }
        public CreateModel(IProductApplication productApplication, IOccasionalDiscountsApplication occasionalDiscountsApplication)
        {
            _productApplication = productApplication;
            _occasionalDiscountsApplication = occasionalDiscountsApplication;
        }

        public void OnGet()
        {
            SelectLists = new SelectList(_productApplication.GetModelProducts(),"Id","Name");
        }
        public IActionResult OnPost(CreateOccasionalDiscounts command)
        {
            var result = _occasionalDiscountsApplication.Create(command);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Create");
        }
    }
}
