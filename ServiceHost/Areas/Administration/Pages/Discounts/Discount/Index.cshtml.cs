using DiscountManagement.Application.Contract.DiscountApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Discounts.Discount
{
    public class IndexModel : PageModel
    {
        private readonly IDiscountApplication _discountApplication;
        private readonly IProductApplication _productApplication;
        public List<ViewModelDiscount> Discounts { get; set; }
        public SearchModelDiscount SearchModel { get; set; }
        public SelectList SelectLists { get; set; }
        public IndexModel(IDiscountApplication discountApplication, IProductApplication productApplication)
        {
            _discountApplication = discountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(SearchModelDiscount searchModel)
        {
            Discounts = _discountApplication.Search(searchModel);
            SelectLists = new SelectList(_productApplication.GetModelProducts(), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var discount = new DefinitionDiscount()
            {
                ModelProducts = _productApplication.GetModelProducts(),
                DiscountsTypeModel = DiscountType.ListDiscount()
            };
            return Partial("./Create", discount);
        }
        public JsonResult OnPostCreate(DefinitionDiscount command)
        {
            var result = _discountApplication.Definition(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var discount = _discountApplication.GetEdit(id);
            discount.ModelProducts = _productApplication.GetModelProducts();
            discount.DiscountsTypeModel = DiscountType.ListDiscount();
            return Partial("./Edit", discount);
        }
        public JsonResult OnPostEdit(EditDiscount command)
        {
            var result = _discountApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved(long id)
        {
            _discountApplication.Remove(id);
            return RedirectToPage("./Index");
        }
         public IActionResult OnGetRestore(long id)
        {
            _discountApplication.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}
