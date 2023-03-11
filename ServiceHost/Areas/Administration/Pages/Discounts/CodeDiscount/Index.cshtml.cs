using DiscountManagement.Application.Contract.CodeDiscountApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Discounts.CodeDiscount
{
    public class IndexModel : PageModel
    {
        private readonly ICodeDiscountApplication _codeDiscountApplication;
        private readonly IProductApplication _productApplication;
        public List<ViewModelCodeDiscount> codeDiscounts{ get; set; }
        public SearchModelDiscount SearchModel { get; set; }
        public SelectList SelectLists{ get; set; }
        public IndexModel(ICodeDiscountApplication codeDiscountApplication, IProductApplication productApplication)
        {
            _codeDiscountApplication = codeDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(SearchModelDiscount searchModel)
        {
            codeDiscounts = _codeDiscountApplication.Search(searchModel);
            SelectLists = new SelectList(_productApplication.GetModelProducts(),"Id","Name");

        }
        public IActionResult OnGetCreate()
        {
            var codeDiscount = new CreateCodelDiscount()
            {
                ModelProducts = _productApplication.GetModelProducts()
            };
            return Partial("./Create", codeDiscount);
        }
        public JsonResult OnPostCreate(CreateCodelDiscount command)
        {
            var result = _codeDiscountApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var codeDiscount = _codeDiscountApplication.GetEdit(id);
            codeDiscount.ModelProducts = _productApplication.GetModelProducts();
            return Partial("./Edit", codeDiscount);
        }
        public JsonResult OnPostEdit(EditCodeDiscount command)
        {
            var result = _codeDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            _codeDiscountApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            _codeDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
