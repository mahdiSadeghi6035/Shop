using DiscountManagement.Application.Contract.OccasionalDiscountsApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost.Areas.Administration.Pages.Discounts.OccasionalDiscounts
{
    public class EditModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IOccasionalDiscountsApplication _occasionalDiscountsApplication;
        public EditOccasionalDiscounts Command { get; set; }
        public List<SelectListItem> SelectLists = new List<SelectListItem>();
        public EditModel(IProductApplication productApplication, IOccasionalDiscountsApplication occasionalDiscountsApplication)
        {
            _productApplication = productApplication;
            _occasionalDiscountsApplication = occasionalDiscountsApplication;
        }

        public void OnGet(long id)
        {
            Command = _occasionalDiscountsApplication.GetEdit(id);
            var product = _productApplication.GetModelProducts();
            foreach (var item in product)
            {
                var productItem = new SelectListItem(item.Name, item.Id.ToString());
                if (Command.ProductDiscount.Any(x => x.Id == item.Id))
                    productItem.Selected = true;
                SelectLists.Add(productItem);
            }
        }
        public IActionResult OnPost(EditOccasionalDiscounts command)
        {
            var result = _occasionalDiscountsApplication.Edit(command);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Edit");
        }
    }
}
